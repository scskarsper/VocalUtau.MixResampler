using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocalUtau.MixResampler.Model.Args;

namespace VocalUtau.MixResampler
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
             
726                     string[] resampler_arg_prefix = new string[] { "\"" + wavPath + "\"" }; 
727                     string[] resampler_arg_suffix = new string[]{ 
728                         "\"" + note + "\"", 
729                         "100",//<==VEL 
730                         "\"" + UtauPitchBendGenerator.FlagGener(target,item) + "\"", 
731                         (oa.msOffset+item.UstEvent.LeftLimit).ToString() + "", 
732                         millisec + "", 
733                         oa.msConsonant + "", 
734                         oa.msBlank + "", 
735                         item.UstEvent.getIntensity() + "", 
736                         item.UstEvent.getModuration() + "", 
737                         "!"+BASE_TEMPO + "" }; 
738 
 

             
             */
            ArgsStruct p = ArgsParser.parseArgs(args);
            if (p == null)
            {
                ArgsParser.printUsage();
                return;
            }
            ArgsParser.printArgs(p);
        }
    }
}
