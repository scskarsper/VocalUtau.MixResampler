using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocalUtau.MixResampler.Model.Args
{
    public class ArgsParser
    {
        public static void printUsage()
        {
            Console.WriteLine("mixResampler.exe [Options/Commands] <infile> <outfile> <tone> <velocity> <flags> <offset>");
            Console.WriteLine("             <length_req> <fixed_length> <endblank> <intensity> <modulation> <tempo> <pitch_bends>");
        }
        public static void printArgs(ArgsStruct p)
        {
            Console.WriteLine("Input: {0}", p.Inputfilename);
            Console.WriteLine("Output: {0}", p.Outputfilename);
            Console.WriteLine("Tone: {0}", p.Tone);
            Console.WriteLine("Velocity: {0}", p.Velocity);
            Console.WriteLine("Flags: {0}", p.Flags);
            Console.WriteLine("Offset: {0}", p.Offset);
            Console.WriteLine("LengthRequire: {0}", p.Length_Require);
            Console.WriteLine("FixedLength: {0}", p.Fixed_Length);
            Console.WriteLine("EndBlank: {0}", p.End_Blank);
            Console.WriteLine("Intensity: {0}", p.Intensity);
            Console.WriteLine("Modulation: {0}", p.Modulation);
            Console.WriteLine("Tempo: {0}", p.Tempo);
            Console.Write("PitchBends: ");
            for (int i = 0; i < p.PitchBends.Count; i++)
            {
                Console.Write(p.PitchBends[i].ToString() + " ");
            }
            Console.WriteLine("");
        }
        public static ArgsStruct parseArgs(string[] args, bool OptionOrCommandCaseSensitive = true)
        {
            Dictionary<string, string> Options = new Dictionary<string, string>();
            List<string> Commands = new List<string>();
            List<string> argList = new List<string>();
            argList.AddRange(args);
            if (argList.Count == 0) return null;
            while (argList.Count > 0 && (argList[0].Length > 10 && (argList[0].Substring(0, 10).ToLower() == "--options-" || argList[0].Substring(0, 10).ToLower() == "--command-")))
            {
                string ostr = argList[0];
                argList.RemoveAt(0);
                string tyr = ostr.Substring(0, 10).ToLower();
                ostr = ostr.Substring(10);
                if (tyr == "--options-")
                {
                    int spt = ostr.IndexOf(":");
                    string k = ostr;
                    string v = "true";
                    if (spt > 0)
                    {
                        k = ostr.Substring(0, spt);
                        v = ostr.Substring(spt + 1);
                    }
                    if (!OptionOrCommandCaseSensitive) k = k.ToLower();
                    if (!Options.ContainsKey(k)) Options.Add(k, v);
                }
                else if (tyr == "--command-")
                {
                    if (!OptionOrCommandCaseSensitive) ostr = ostr.ToLower();
                    Commands.Add(ostr);
                }
            }
            ArgsStruct ret = parseArgs_resampletool(argList.ToArray());
            ret.Options = Options;
            ret.Commands = Commands;
            return ret;
        }
        private static ArgsStruct parseArgs_resampletool(string[] args)
        {
            if (args.Length < 2) return null;
            ArgsStruct ret = new ArgsStruct();

            ret.Inputfilename = args[0];
            ret.Outputfilename = args[1];
            ret.Tone = args[2];
            ret.Velocity = Conversion.Val(args[3]);
            if (args.Length > 5)ret.Flags = args[4];
            if (args.Length > 6) ret.Offset = Conversion.Val(args[5]);
            if (args.Length > 7) ret.Length_Require = Conversion.Val(args[6]);
            if (args.Length > 8) ret.Fixed_Length = Conversion.Val(args[7]);
            if (args.Length > 9) ret.End_Blank = Conversion.Val(args[8]);
            if (args.Length > 10) ret.Intensity = Conversion.Val(args[9]);
            if (args.Length > 11) ret.Modulation = Conversion.Val(args[10]);
            if (args.Length > 12)
            {
                string Tepo = args[11].Trim();
                if (Tepo[0] == '!')
                {
                    ret.Tempo = Conversion.Val(Tepo.Substring(1));
                }
                else
                {
                    ret.Tempo = Conversion.Val(Tepo);
                }
            }
            if (args.Length > 4) ret.PitchBends = PitchParamUtils.Decode(args[args.Length-1]);
            return ret;
        }
    }
}
