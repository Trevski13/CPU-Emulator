/*
 * Trevor Buttrey
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiCore
{
    public class Instruction
    {
        public Instruction(byte InstructionValue, byte DataValue)
        {
            this.InstructionValue = InstructionValue;
            this.DataValue = DataValue;
        }
        public byte InstructionValue { get; set; }
        public byte DataValue { get; set; }

        //public string


    }
}
