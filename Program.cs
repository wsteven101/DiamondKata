////////////////////////////////////////////////////////////////////////////////////////
// Program to output a diamond whose edges are formed of letters
// Parameters: A single letter represent the mid (widest) point of the diamond
//
// Example: a parameter of 'B' outputs....
//
//        A
//       B B
//        A
///////////////////////////////////////////////////////////////////////////////////////

using DiamondKata;


if ((args.Length == 0) || (args.Length) > 1)
{
    Console.WriteLine("Only a single character may be provided as a parameter");
    return;
}

var diamond = new Diamond();
var diamondOutput = diamond.GetDiamond(args[0][0]);

Console.WriteLine($"{diamondOutput}");
