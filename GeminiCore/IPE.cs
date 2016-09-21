/**
 * Trevor Buttrey
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeminiCore
{
    public class IPE
    {
        public string ParserSuccess { get; private set;}
        
        public string FileToParse { get; set; }

        private byte encoding;

        private byte data;

        private int lineNumber;

        private Dictionary<string, int> labels = new Dictionary<string, int> { };

        public IPE(string filename)
        {
            this.FileToParse = filename;
           
        }

        private int binaryToDecimal(string number)
        {
            return Convert.ToInt32(number, 2);
        }
        private string decimalToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }
        private byte EncodeInstruction(string instruction, string value)
        {
            Console.WriteLine("Parser: Encoding...");
            if (instruction == "nop")
            {
                return Convert.ToByte(0); ;  //new byte[] { 0, 0, 0, 0, 0, 0, 0, 0}; //binaryToDecimal("00000000");
            }
            else if (instruction == "lda")
            {
                if (value[0] == '#')
                {
                    return 128;  //new byte[] { 0, 1, 0, 0, 0, 0, 0, 0}; //binaryToDecimal("00000010"); ;
                }
                else
                {
                    return 129;  //new byte[] { 1, 1, 0, 0, 0, 0, 0, 0 }; //binaryToDecimal("00000011"); ;
                }
            }
            else if (instruction == "sta")
            {
                return 64;  //new byte[] { 0, 0, 1, 0, 0, 0, 0, 0 }; //binaryToDecimal("00000100");
            }
            else if (instruction == "add")
            {
                if (value[0] == '#')
                {
                    return 192;  //new byte[] { 0, 1, 1, 0, 0, 0, 0, 0 }; //binaryToDecimal("00000110");
                }
                else
                {
                    return 193;  //new byte[] { 1, 1, 1, 0, 0, 0, 0, 0 }; //binaryToDecimal("00000111");
                }
            }
            else if (instruction == "sub")
            {
                if (value[0] == '#')
                {
                    return 32;  //new byte[] { 0, 0, 0, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001000");
                }
                else
                {
                    return 33;  //new byte[] { 1, 0, 0, 1, 0, 0, 0, 0 }; //binaryToDecimal("000001001");
                }
            }
            else if (instruction == "mul")
            {
                if (value[0] == '#')
                {
                    return 144;  // new byte[] { 0, 1, 0, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001010");
                }
                else
                {
                    return 145;  //new byte[] { 1, 1, 0, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001011");
                }
            }
            else if (instruction == "div")
            {
                if (value[0] == '#')
                {
                    return 80;  //new byte[] { 0, 0, 1, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001100");
                }
                else
                {
                    return 81;  //new byte[] { 1, 0, 1, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001101");
                }
            }
            else if (instruction == "and")
            {
                if (value[0] == '#')
                {
                    return 208;  //new byte[] { 0, 1, 1, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001110");
                }
                else
                {
                    return 209;  //new byte[] { 1, 1, 1, 1, 0, 0, 0, 0 }; //binaryToDecimal("00001111");
                }
            }
            else if (instruction == "or")
            {
                if (value[0] == '#')
                {
                    return 48;  //new byte[] { 0, 0, 0, 0, 1, 0, 0, 0 }; //binaryToDecimal("00010000");
                }
                else
                {
                    return 49;  //new byte[] { 1, 0, 0, 0, 1, 0, 0, 0 }; //binaryToDecimal("00010001");
                }
            }
            else if (instruction == "shl")
            {
                return 176;  //new byte[] { 0, 1, 0, 0, 1, 0, 0, 0 }; //binaryToDecimal("00010010");
            }
            else if (instruction == "nota")
            {
                return 240;  //new byte[] { 0, 0, 1, 0, 1, 0, 0, 0}; //binaryToDecimal("00010100");
            }
            else if (instruction == "ba")
            {
                return 8;  //new byte[] { 0, 1, 1, 0, 1, 0, 0, 0 }; //binaryToDecimal("00010110");
            }
            else if (instruction == "be")
            {
                return 136;  //new byte[] { 0, 0, 0, 1, 1, 0, 0, 0 }; //binaryToDecimal("00011000");
            }
            else if (instruction == "bl")
            {
                return 72;  //new byte[] { 0, 1, 0, 1, 1, 0, 0, 0 }; //binaryToDecimal("00011010");
            }
            else if (instruction == "bg")
            {
                return 200;  //new byte[] { 0, 0, 1, 1, 1, 0, 0, 0 }; //binaryToDecimal("00011110");
            }
            else if (instruction == "ba")
            {
                return 40;  //new byte[] { 0, 1, 1, 1, 1, 0, 0, 0 }; //binaryToDecimal("00100000");
            }
            else if (instruction == "hlt")
            {
                return 168;
            }
            else
            {
                throw new ArgumentException("Invalid Instruction", instruction);
                //return -1;
            }
        }

        public void ParseFile()
        {
            try
            {
                Console.WriteLine("Parser: Reading in file...");
                var lines = File.ReadAllLines(this.FileToParse).ToList<string>();
                Console.WriteLine("Parser: File Read");

                Console.WriteLine("Parser: Opening Output File...");
                BinaryWriter output = new BinaryWriter(File.Open("g.out", FileMode.Create));
                Console.WriteLine("Parser: Output File Opened");
                //outputFile = File.Open("file.bin", FileMode.Create);



                Console.WriteLine("Parser: Scaning for Labels...");
                lineNumber = 0;
                foreach (var line in lines)
                {
                    lineNumber++;
                    Regex labelStmtFormat = new Regex(@"^(?<label>.*?)\s*:$");
                    var labelStmtMatch = labelStmtFormat.Match(line);
                    if (labelStmtMatch.Success)
                    {
                        var label = labelStmtMatch.Groups["label"].Value;
                        labels[label.ToString()] = lineNumber;
                        Console.WriteLine("Parser: Label: \"" + label.ToString() + "\" at line: " + lineNumber);
                    }
                }
                Console.WriteLine("Parser: Labels Scanned");



                Console.WriteLine("Parser: Reading in Instructions...");
                try
                {
                    foreach (var line in lines)
                    {
                        Console.WriteLine("--------------new Instruction--------------");
                        Regex labelStmtFormat = new Regex(@"^(?<label>.*?)\s*:$");
                        //Regex instructionStmtFormat = new Regex(@"^\s*(?<instruction>[a-z]+)(\s*$|(\s+(?<value>\S+)\s*.*$");
                        //Regex instructionStmtFormat = new Regex(@"^\s*(?<instruction>[a-z]+)(\s*$|(\s+(?<value>\S+))(\s*$|\s+!.*$))");
                        Regex instructionStmtFormat = new Regex(@"^\s*(?<instruction>[a-z]+)((\s*$|\s+[!].*$)|(\s+(?<value>([#][$][0-9]*)|[$][0-9]*|[a-z0-9]*))(\s*$|\s+[!].*$))");
                        Regex spaceStmtFormat = new Regex(@"^(\s*|\s*!.*)$");
                        //^\s*([a-z]+)\s+(\S+)\s+.*$
                        //^\s*([a-z]+)(\s*$|(\s+(\S+))(\s*$|\s+!.*$))
                        //^\s*([a-z]+)((\s*$|\s+[!].*$)|(\s+([#][$][0-9]*|[$][0-9]*|[a-z0-9]*))(\s*$|\s+[!].*$))
                        var labelStmtMatch = labelStmtFormat.Match(line);
                        var instructionStmtMatch = instructionStmtFormat.Match(line);
                        var spaceStmtMatch = spaceStmtFormat.Match(line);
                        Console.WriteLine("Parser: Line: \"" + line + "\"");
                        if (labelStmtMatch.Success)
                        {
                            Console.WriteLine("Parser: Label");
                            encoding = EncodeInstruction("nop", "");
                        }
                        else if (instructionStmtMatch.Success)
                        {
                            var instruction = instructionStmtMatch.Groups["instruction"].Value;
                            var value = instructionStmtMatch.Groups["value"].Value;
                            Console.WriteLine("Parser: Instruction is \"" + instruction.ToString() + "\" and value is \"" + value.ToString() + "\"");
                            encoding = EncodeInstruction(instruction.ToString(), value.ToString());
                            Console.WriteLine("Parser: Instruction Encoded");
                            Console.WriteLine("Parser: Encoding data...");
                            if (value.ToString() == "")
                            {
                                data = Convert.ToByte(0);
                            }
                            else if (value.ToString()[0] == '#')
                            {
                                try
                                {
                                    data = Convert.ToByte(value.Substring(2));
                                }
                                catch (System.OverflowException e)
                                {
                                    throw new ArgumentException("The Data is to large");
                                }

                            }
                            else if (value.ToString()[0] == '$')
                            {
                                try
                                {
                                    data = Convert.ToByte(value.Substring(1));
                                }
                                catch (System.OverflowException e)
                                {
                                    throw new ArgumentException("The Data is to large");
                                }
                            }
                            else if (labels.ContainsKey(value.ToString()))
                            {
                                data = Convert.ToByte(labels[value.ToString()]);
                            }
                            else if (value.ToString()[0] == '!')
                            {
                                data = Convert.ToByte(0); //I'll fixes this with the regex at somepoint...
                            }
                            else
                            {
                                Console.WriteLine("Parser: Data not valid");
                                throw new ArgumentException("Invalid Data");
                            }
                            Console.WriteLine("Parser: Data Encoded");
                        }
                        else if (spaceStmtMatch.Success)
                        {
                            Console.WriteLine("Parser: WhiteSpace");
                            encoding = EncodeInstruction("nop", "");
                            data = Convert.ToByte(0); ;
                        }
                        else
                        {
                            Console.WriteLine("Parser: No Match");
                            throw new ArgumentException("Invalid Line", line);
                        }


                        Console.WriteLine("Parser: Encoding is: " + encoding);
                        Console.WriteLine("Parser: Writing Encoding to File...");
                        output.BaseStream.WriteByte(encoding);

                        Console.WriteLine("Parser: Wrote Encoding to File...");

                        Console.WriteLine("Parser: Value is: " + data);
                        Console.WriteLine("Parser: Writing Value to File...");
                        output.BaseStream.WriteByte(data);
                        Console.WriteLine("Parser: Wrote Value to File");
                    }
                }
                catch (ArgumentException e)
                {
                    throw e;
                }

                Console.WriteLine("Parser: Instructions Read");
                Console.WriteLine("Parser: Closing Output File...");
                output.Close();
                Console.WriteLine("Parser: Output File Closed");
                System.Windows.Forms.MessageBox.Show("Binary has been sucessfully output");
            }
            catch(ArgumentException e)
            {
                System.Windows.Forms.MessageBox.Show("There was an error parsing the file at line " + lineNumber + "\n\nDetails:\n" + e.ToString() + "\n\nPlease note that you wil NOT be able to run the program until the source is fixed");
            }
            catch (System.IO.IOException e)
            {
                System.Windows.Forms.MessageBox.Show("Unable to open output file, is it already open?");
            }
        }
    }
}
