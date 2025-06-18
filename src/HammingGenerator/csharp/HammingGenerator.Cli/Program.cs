namespace HammingGenerator.Cli;

internal class Program
{
    static void Main(string[] args)
    {
        var bitdepth = 5;
        var mask = (int)Math.Pow(2, bitdepth) - 1;

        for (var distance = 0; distance < bitdepth; distance++)
        {
            if (distance == 0)
            {
                //Console.WriteLine($"{Convert.ToString(mask, 2).PadLeft(10, '0')}\t0");
            }
            else
            {
                var bitCnt = distance;
                var shiftCnt = bitdepth - distance;

                Console.WriteLine($"b:{bitCnt}\ts:{shiftCnt}");

                var set = new List<int>();
                var oset = new List<int>();
                for (var b = 0; b < bitdepth; b++)
                {
                    set.Add(1 << b);
                }

                if (bitCnt == 1)
                {
                    oset = set;
                }
                else if (bitCnt > 1)
                {
                    for (var s = 1; s < bitCnt; s++)
                    {
                        var pSet = set.ToArray();
                        foreach (var p in pSet)
                        {
                            var v = (p << 1) + 1;
                            //if (s == (bitCnt - 1))
                            {
                                set.Add(v);
                            }
                            if (s ==( bitCnt - 1))
                            {
                                oset.Add(v);
                            }
                        }
                    }
                }

                foreach (var b in oset)
                {
                    Console.WriteLine(Convert.ToString(b, 2).PadLeft(8, '0'));
                }


                //var bits = from b in Enumerable.Range(0, bitdepth)
                //           let i = (1 << b) << (distance - 1)
                //           where i < mask
                //           select i + (distance - 1);

                //var cnt = Math.Ceiling((float)bitdepth / bits.Count());
                //Console.WriteLine(cnt);

                ////for (var c = 0; c < cnt; c++)
                //    foreach (var imask in bits)
                //    {
                //        Console.WriteLine($"{Convert.ToString(imask, 2).PadLeft(10, '0')}\t{distance}\t{imask}");
                //    }
            }

            Console.WriteLine(new string('-', 10));
        }

        //var bits = 2;
        //for (var s = 0; s < bits; s++)
        //{
        //    for (var b = 0; b < bitdepth; b++)
        //    {
        //        //Console.WriteLine($"{mask - (1 << b)}\t1");
        //    }

        //    //Console.WriteLine($"{mask - (1 << b)}\t1");
        //}



        //var query = from distance in Enumerable.Range(0, bitdepth)
        //            select new
        //            {
        //                mask,
        //                distance,
        //            };

        //foreach (var item in query)
        //{
        //    Console.WriteLine(item);
        //    Console.WriteLine($"\tShifts:{bitdepth - item.distance}");


        //    //var bits = from i in Enumerable.Range(0, bitdepth)
        //    //           select new
        //    //           {
        //    //               bit = 1 << i,
        //    //           };

        //    //foreach (var i in bits)
        //    //{
        //    //    Console.WriteLine($"\t{i}");
        //    //}



        //}
    }
}
