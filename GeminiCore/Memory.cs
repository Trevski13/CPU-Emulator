/**
 * Trevor Buttrey
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiCore
{
    
    public class Memory
    {
        private List<Instruction> Instructions = new List<Instruction> { };
        private short[] RAM = new short[256];
        private short[] Cache;
        public byte CacheSize = 0;
        public Instruction getInstructionAt(byte Location)
        {
            try
            {
                if (Location < Instructions.Count)
                {
                    return Instructions[Location];
                }
                else
                {
                    throw new NullReferenceException("Out of Range");
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Memory: Instruction Access Error");
                throw e;
            }
            
        }

        /*public ushort getRawInstructionAt(byte Location)
        {
            try
            {
                if (Location < Instructions.Count)
                {
                    return Instructions[Location].;
                }
                else
                {
                    throw new NullReferenceException("Out of Range");
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Memory: Instruction Access Error");
                throw e;
            }

        }*/

        public void addInstruction(byte Instruction, byte Data)
        {
            Instructions.Add(new Instruction(Instruction, Data));
        }
        public void clearInstructions()
        {
            Instructions.Clear();
        }
        public short getDataAt(byte Location){
            if (CacheSize > 0)
            {
                //Cache stuff
                return 0;
            }
            else
            {
                return RAM[Location];
            }
        }
        public void setDataAt(byte Location, short Data)
        {
            if (CacheSize > 0)
            {
                //Cache stuff
            }
            else
            {
                RAM[Location] = Data;
            }
        }

        public void setCache(byte size)
        {
            CacheSize = size;
            this.Cache = new short[CacheSize];
        }
    }
}
