using System.Text;

namespace Fuvarozas
{
    internal class Program
    {
        public static List<Fuvar> fuvarList = new List<Fuvar>();
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("fuvar.csv"))
            {
                StreamWriter sw = new StreamWriter("hibak.txt", true, Encoding.UTF8);
                sr.ReadLine();
                while (!sr.EndOfStream)
                { 
                    string[] line = sr.ReadLine().Trim().Split(";");

                    if (int.Parse(line[2]) > 0 && float.Parse(line[4]) > 0 && float.Parse(line[3]) == 0)
                    {
                        sw.WriteLine($"{line[0]};{line[1]};{line[2]};{line[3]};{line[4]};{line[5]};{line[6]}");
                    }
                    else
                    {
                        Fuvar fuvar = new Fuvar(int.Parse(line[0]), line[1], int.Parse(line[2]), float.Parse(line[3]), float.Parse(line[4]), float.Parse(line[5]), line[6]);
                        fuvarList.Add(fuvar);
                    }
                }
                sw.Flush();
                sw.Close();
            }

            Console.WriteLine($"3. feladat: {count_Trips(fuvarList)} fuvar");
            Console.WriteLine($"4. feladat: {get_income_by_id(6185, fuvarList)[1]} fuvar alatt: {get_income_by_id(6185, fuvarList)[0]}" + "$");
            Console.WriteLine("5. feladat: ");
            foreach (var item in get_method_types(fuvarList))
            {
                Console.WriteLine($"\t{item.Key}: {item.Value} fuvar");
            }
            Console.WriteLine($"6. feladat: {get_all_distance(fuvarList)}km");
            Fuvar longest = get_longest_trip(fuvarList);
            Console.WriteLine($"7. feladat: \n\t{longest.length_in_ms} másodperc\n\t{longest.taxiId}\n\t{longest.distance} km\n\t{longest.price}" + "$");
        }

        static int count_Trips(List<Fuvar> list)
        { 
            return list.Count;
        }

        static float[] get_income_by_id(int id, List<Fuvar> list)
        {
            float income = 0;
            List<Fuvar> trips_with_given_id = list.FindAll(item => item.taxiId == id);
            float trips = trips_with_given_id.Count();

            foreach (var item in trips_with_given_id)
            {
                income += item.price + item.tip;
            }

            return new float[] {income, trips };
        }

        static Dictionary<string, int> get_method_types(List<Fuvar> list)
        {
            Dictionary<string, int> paymentMethods = new Dictionary<string, int>();

            foreach (var item in list) 
            {
                if (paymentMethods.ContainsKey(item.paymentMethod))
                {
                    paymentMethods[item.paymentMethod]++;
                }
                else
                {
                    paymentMethods[item.paymentMethod] = 1;
                }
            }

            return paymentMethods;
        }

        static float get_all_distance(List<Fuvar> list)
        {
            float distance = 0;
            foreach (var item in list) 
            { 
                distance += item.distance;
            }
            return distance * (float)1.6;
        }
        static Fuvar get_longest_trip(List<Fuvar> list)
        {
            return list.OrderByDescending(item => item.length_in_ms).FirstOrDefault();
        }
    }
}