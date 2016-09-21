/**
 * Trevor Buttrey
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace GeminiCore
{
    public class CPU
    {
        private Memory RAM = new Memory();
        public int ACC { get; private set; }
        public int A { get; private set; }
        public int B { get; private set; }
        public int Zero { get; private set; }
        public int One { get; private set; }
        public int PC { get; private set; }
        public int MAR { get; private set; }
        public int MDR { get; private set; }
        public int TEMP { get; private set; }
        public int IR { get; private set; }
        private object IR_locker = new object();
        public Instruction IR_D { get; set; }
        public int CC { get; private set; }

        private bool done = false;
        bool loadInst = false;
        bool waitOnMultiply = false;
        int multiplyWaitCount = 0;
        bool fetchDone, decodeDone, executeDone, storeDone;

        Thread fetchThread;
        AutoResetEvent fetchEvent = new AutoResetEvent(false);
        Thread decodeThread;
        AutoResetEvent decodeEvent = new AutoResetEvent(false);
        Thread executeThread;
        AutoResetEvent executeEvent = new AutoResetEvent(false);
        Thread storeThread;
        AutoResetEvent storeEvent = new AutoResetEvent(false);

        AutoResetEvent allThreadsDone = new AutoResetEvent(false);
        object allThreadsDoneLock = new object();

        bool fetchRuns;
        bool decodeRuns;
        bool executeRuns;
        bool storeRuns;

        public struct fetchStruct
        {
            public byte PC;
        }
        public struct decodeStruct
        {
            public byte IRInstruction;
            public byte IRData;
            public byte PC;
        }
        public struct executeStruct
        {
            public byte IRInstruction;
            public byte IRData;
            public byte PC;
        }
        public struct storeStruct
        {
            public byte IRInstruction;
            public byte IRData;
            public short result;
            public byte location;
            public bool isACCValue; //if false then use location to store value at register
            public int PC;
        }
        public struct branchPredictionStruct
        {
            public int branchPC;
            public int targetPC;
            public int takenCount;
            public int notTakenCount;
            public bool taken;
            public bool predictTaken;
        }

        public struct opperateResultStruct
        {
            public short result;
            public byte location;
            public bool isACCValue;
        }

        //private fetchStruct? fetchData = null;
        //private decodeStruct? decodeData = null;
        //private executeStruct? executeData = null;
        //private storeStruct? storeData = null;

        public delegate void FetchDone(object sender, OperationEventArgs args);
        public event FetchDone OnFetchDone;

        public delegate void DecodeDone(object sender, OperationEventArgs args);
        public event DecodeDone OnDecodeDone;

        public delegate void ExecuteDone(object sender, OperationEventArgs args);
        public event ExecuteDone OnExecuteDone;

        public delegate void StoreDone(object sender, OperationEventArgs args);
        public event StoreDone OnStoreDone;


        fetchStruct fetch = new fetchStruct();
        decodeStruct decode = new decodeStruct();
        executeStruct execute = new executeStruct();
        storeStruct store = new storeStruct();

        public CPU()
        {
            PC = 0;
            Zero = 0;
            One = 1;

            fetchThread = new Thread(new ThreadStart(Fetch));
            fetchThread.Name = "Fetch Thread";
            fetchThread.Start();
            decodeThread = new Thread(new ThreadStart(Decode));
            decodeThread.Name = "Decode Thread";
            decodeThread.Start();
            executeThread = new Thread(new ThreadStart(Execute));
            executeThread.Name = "Execute Thread";
            executeThread.Start();
            storeThread = new Thread(new ThreadStart(Store));
            storeThread.Name = "Store Thread";
            storeThread.Start();

            this.OnFetchDone += CPU_OnThreadDone;
            this.OnDecodeDone += CPU_OnThreadDone;
            this.OnStoreDone += CPU_OnThreadDone;
            this.OnExecuteDone += CPU_OnThreadDone;
        }

        public void setCC(){
            if (ACC > 0){ CC = 1; }
            else if (ACC < 0){ CC = -1; }
            else { CC = 0;  }
        }

        public void Reset()
        {
            Console.WriteLine("CPU: Resetting CPU...");
            PC = 0;
            ACC = 0;
            A = 0;
            B = 0;
            MAR = 0;
            MDR = 0;
            TEMP = 0;
            IR = 0;
            CC = 0;
            for (byte i = 0; i <= 254; i++)
            {
                //Console.WriteLine("CPU: Memory at " + i + " Cleared");
                RAM.setDataAt(i, 0);
            }
            RAM.clearInstructions();
            Console.WriteLine("CPU: CPU Reset");
        }

        void CPU_OnThreadDone(object sender, OperationEventArgs args)
        {
            // if all threads are done (use bools)
            switch (args.CurrentThreadType)
            {
                case ThreadType.Fetch:
                    fetchDone = true;
                    break;
                case ThreadType.Decode:
                    decodeDone = true;
                    break;
                case ThreadType.Execute:
                    executeDone = true;
                    break;
                case ThreadType.Store:
                    storeDone = true;
                    break;
            }
            lock (allThreadsDoneLock)
            {
                if (fetchDone && decodeDone && executeDone && storeDone)
                {
                    allThreadsDone.Set();
                }
            }
        }

        public void Dispose()
        {
            done = true;

            fetchEvent.Set();
            fetchThread.Join();

            decodeEvent.Set();
            decodeThread.Join();

            executeEvent.Set();
            executeThread.Join();

            storeEvent.Set();
            storeThread.Join();
        }

        public void nextInstruction()
        {
            try
            {
                //Instruction InstructionValue = RAM.getInstructionAt(Convert.ToByte(PC));
                //opperate(InstructionValue.InstructionValue, InstructionValue.DataValue);
                fetchDone = false;
                decodeDone = false;
                executeDone = false;
                storeDone = false;

                if (loadInst)
                {
                    loadInst = false;
                }
                else if (waitOnMultiply)
                {
                    if (multiplyWaitCount == 4)
                    {
                        multiplyWaitCount = 0;
                        waitOnMultiply = false;
                    }
                    else
                    {
                        multiplyWaitCount++;
                    }
                }
                //TODO Add branch prediction logic
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("CPU: No More Instructions");
                System.Windows.Forms.MessageBox.Show("Execution Has Competed");
                return;
            }
            //PC++;
        }
        public void runToComplete()
        {
            while (!done)
            {
                try
                {
                    //Instruction InstructionValue = RAM.getInstructionAt(Convert.ToByte(PC));
                    //opperate(InstructionValue.InstructionValue, InstructionValue.DataValue);
                    fetchDone = false;
                    decodeDone = false;
                    executeDone = false;
                    storeDone = false;

                    if (loadInst)
                    {
                        loadInst = false;
                    }
                    else if (waitOnMultiply)
                    {
                        if (multiplyWaitCount == 4)
                        {
                            multiplyWaitCount = 0;
                            waitOnMultiply = false;
                        }
                        else
                        {
                            multiplyWaitCount++;
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("CPU: No More Instructions");
                    done = true;
                }
                PC++;
            }
            PC--;
            System.Windows.Forms.MessageBox.Show("Execution Has Competed");
        }

        private void Fetch()
        {
            while (!done)
            {
                fetchEvent.WaitOne();

                if (fetchRuns)
                {
                    Console.WriteLine("In Fetch");
                    Instruction IR = RAM.getInstructionAt(fetch.PC);
                    decode.IRInstruction = IR.InstructionValue;
                    decode.IRData = IR.DataValue;
                    fetch.PC++;
                }

                if (OnFetchDone != null)
                {
                    OnFetchDone(this, new OperationEventArgs(ThreadType.Fetch, this.IR));
                }
            }
        }

        public void Decode()
        {
            while (!done)
            {
                decodeEvent.WaitOne();

                if (decodeRuns)
                {
                    Console.WriteLine("In Decode");
                    //It's actually already Decoded...
                    execute.IRInstruction = decode.IRInstruction;
                    execute.IRData = decode.IRData;
                    execute.PC = decode.PC;
                }
                if (OnDecodeDone != null)
                {
                    OnDecodeDone(this, new OperationEventArgs(ThreadType.Decode, this.IR));
                }
            }
        }

        public void Execute()
        {
            while (!done)
            {
                executeEvent.WaitOne();
                if (executeRuns)
                {
                    Console.WriteLine("In Execute");
                    store.IRInstruction = execute.IRInstruction;
                    store.IRData = execute.IRData;
                    opperateResultStruct result = opperate(execute.IRInstruction, execute.IRData);
                    store.result = result.result;
                    store.location = result.location;
                    store.isACCValue = result.isACCValue;
                }
                if (OnExecuteDone != null)
                {
                    OnExecuteDone(this, new OperationEventArgs(ThreadType.Execute, this.IR));
                }
            }
        }

        public void Store()
        {
            while (!done)
            {
                executeEvent.WaitOne();
                if (executeRuns)
                {
                    Console.WriteLine("In Store");
                    if (store.isACCValue)
                    {
                        ACC = store.result;
                        setCC();
                    }
                    else
                    {
                        RAM.setDataAt(store.location, store.result);
                    }
                }
                if (OnExecuteDone != null)
                {
                    OnExecuteDone(this, new OperationEventArgs(ThreadType.Store, this.IR));
                }
            }
        }

        public opperateResultStruct opperate(byte Instruction, byte Data)
        {
            opperateResultStruct result = new opperateResultStruct();
            Console.WriteLine("CPU: Operate: Instruction: " + Instruction + " Data: " + Data);
            if (Instruction == 0) { NOP(); }
            else if (Instruction == 128) { result = LDA(Data); }
            else if (Instruction == 129) { result = LDA(RAM.getDataAt(Data)); }
            else if (Instruction == 64) { result = STA(Data); }
            else if (Instruction == 192) { result = ADD(Data); }
            else if (Instruction == 193) { result = ADD(RAM.getDataAt(Data)); }
            else if (Instruction == 32) { result = SUB(Data); }
            else if (Instruction == 33) { result = SUB(RAM.getDataAt(Data)); }
            else if (Instruction == 144) { result = MUL(Data); }
            else if (Instruction == 145) { result = MUL(RAM.getDataAt(Data)); }
            else if (Instruction == 80) { result = DIV(Data); }
            else if (Instruction == 81) { result = DIV(RAM.getDataAt(Data)); }
            else if (Instruction == 208) { result = AND(Data); }
            else if (Instruction == 209) { result = AND(RAM.getDataAt(Data)); }
            else if (Instruction == 48) { result = OR(Data); }
            else if (Instruction == 49) { result = OR(RAM.getDataAt(Data)); }
            else if (Instruction == 176) { result = SHL(Data); }
            else if (Instruction == 240) { result = NOTA(); }
            else if (Instruction == 8) { result = BA(Data); }
            else if (Instruction == 136) { result = BE(Data); }
            else if (Instruction == 72) { result = BL(Data); }
            else if (Instruction == 200) { result = BG(Data); }
            else if (Instruction == 40) { result = BA(Data); }
            else if (Instruction == 168) { result = HLT(); }
            else { throw new ArgumentException("Invalid Instruction"); }
            return result;
        
        }
        private opperateResultStruct NOP() { Console.WriteLine("CPU: NOP"); return new opperateResultStruct(); }

        private opperateResultStruct LDA(short Data)
        {
            Console.WriteLine("CPU: LDA, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = Data;
            result.isACCValue = true;
            return result;
        }
        private opperateResultStruct STA(short Data)
        {
            Console.WriteLine("CPU: STA, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.location = (byte)Data;
            result.result = (short)ACC;
            result.isACCValue = false;
            return result;
            /*try
            {
                RAM.setDataAt(Convert.ToByte(Data), Convert.ToInt16(ACC));
            }
            catch(System.OverflowException e)
            {
                System.Windows.Forms.MessageBox.Show("ACC does not fit into memory\nExecution Halted");
                HLT();
            }*/
        }
        private opperateResultStruct ADD(short Data)
        {
            Console.WriteLine("CPU: ADD, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = (short)(ACC + Data);
            result.isACCValue = true;
            //setCC();
            return result;
        }
        private opperateResultStruct SUB(short Data)
        {
            Console.WriteLine("CPU: SUB, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = (short)(ACC - Data);
            result.isACCValue = true;
            //setCC();
            return result;
        }
        private opperateResultStruct MUL(short Data)
        {
            Console.WriteLine("CPU: MUL, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = (short)(ACC * Data); //TODO: account for overflow
            result.isACCValue = true;
            //setCC();
            return result;
        }
        private opperateResultStruct DIV(short Data)
        {
            Console.WriteLine("CPU: DIV, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = (short)(ACC / Data); //TODO: Double check this
            result.isACCValue = true;
            //setCC();
            return result;
        }
        private opperateResultStruct AND(short Data)
        {
            Console.WriteLine("CPU: AND, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = Convert.ToByte(Convert.ToByte(ACC) & Convert.ToByte(Data));
            result.isACCValue = true;
            return result;
        }
        private opperateResultStruct OR(short Data)
        {
            Console.WriteLine("CPU: OR, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = Convert.ToByte(Convert.ToByte(ACC) | Convert.ToByte(Data));
            result.isACCValue = true;
            return result;
        }
        private opperateResultStruct SHL(short Data)
        {
            Console.WriteLine("CPU: SHL, Data: " + Data);
            opperateResultStruct result = new opperateResultStruct();
            result.result = Convert.ToByte(Convert.ToByte(ACC) << Convert.ToByte(Data));
            result.isACCValue = true;
            return result;
        }
        private opperateResultStruct NOTA()
        {
            Console.WriteLine("CPU: NOTA");
            try {
                opperateResultStruct result = new opperateResultStruct();
                result.result = Convert.ToByte(Convert.ToByte(ACC) ^ 255);
                result.isACCValue = true;
                return result;
            }
            catch (System.OverflowException e)
            {
                System.Windows.Forms.MessageBox.Show("ACC is not a valid number for NOTA\nExecution Halted");
                HLT();
                return new opperateResultStruct();
            }
        }
        private opperateResultStruct BA(short Data)
        {
            //TODO deal with branches
            HLT();
            Console.WriteLine("CPU: BA, Data: " + Data);
            PC = Data;
            PC--;
            return new opperateResultStruct();
        }
        private opperateResultStruct BE(short Data)
        {
            //TODO deal with branches
            HLT();
            Console.WriteLine("CPU: BE, Data: " + Data);
            if (CC == 0)
            {
                PC = Data;
                PC--;
            }
            return new opperateResultStruct();
        }
        private opperateResultStruct BL(short Data)
        {
            //TODO deal with branches
            HLT();
            Console.WriteLine("CPU: BL, Data: " + Data);
            if (CC == -1)
            {
                PC = Data;
                PC--;
            }
            return new opperateResultStruct();
        }
        private opperateResultStruct BG(short Data)
        {
            //TODO deal with branches
            HLT();
            Console.WriteLine("CPU: BG, Data: " + Data);
            if (CC == 1)
            {
                PC = Data;
                PC--;
            }
            return new opperateResultStruct();
        }
        private opperateResultStruct HLT()
        {
            Console.WriteLine("CPU: HLT");
            return BA(255);
        }
        public void loadBinaryFile(string filename)
        {
            using (BinaryReader input = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                try
                {
                    Console.WriteLine("CPU: Reading In File...");
                    int pos = 0;
                    int length = (int)input.BaseStream.Length;
                    while (pos < length)
                    {
                        Console.WriteLine("CPU: Reading Instruction");
                        byte InstructionValue = input.ReadByte();
                        byte DataValue = input.ReadByte();
                        Console.WriteLine("CPU: Instruction Value: " + InstructionValue + " & Data Value: " + DataValue);
                        RAM.addInstruction(InstructionValue, DataValue);
                        pos += sizeof(byte) * 2;
                    }
                    Console.WriteLine("CPU: Done Reading File");
                    System.Windows.Forms.MessageBox.Show("The Binary file has been sucessfully loaded into memory");
                }
                catch (System.IO.EndOfStreamException)
                {
                    System.Windows.Forms.MessageBox.Show("Unable to read file");
                }
            }
        }

    }
}
