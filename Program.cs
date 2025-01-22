

namespace GenerateID
{
    internal class Program
    {
        static void Main(string[] args)
        {
             var Id = Generator("abc", "xyz", DateTime.Today);
            var Pass = GetPassword(8);
            Console.WriteLine(Id);
            Console.WriteLine(Pass);
            Console.ReadKey();
        }
        public static int LastTowNumbersID { get; set; } = 1;

        public static string Generator(string fname, string lname, DateTime? dateT)
        {
            if (fname == null)
                throw new Exception($"Enter Right {nameof(fname)}");
            if (lname == null)
                throw new Exception($"Enter Right {nameof(lname)}");
            if (dateT == null || dateT.Value.Date < DateTime.Now.Date)
                throw new Exception($"Enter Right {nameof(dateT)}");

            var yy = dateT.Value.ToString("yy");
            var mm = dateT.Value.ToString("MM");
            var dd = dateT.Value.ToString("dd");

            var code = $"{lname.ToUpper()[0]}{fname.ToUpper()[0]}{yy}{mm}{dd}{LastTowNumbersID++.ToString().PadLeft(2, '0')}";
            return code;
        }
        public static string GetPassword(int length)
        {
            const string Name = "zxcvbnmasdfghjklqwertyuiopZXCVBNMASDFGHJKLQWERTYUIOP1234567890";
            Random rnd = new Random();
            var reselt = "";
            while (0 < length--)
            {
                reselt += Name[rnd.Next(Name.Length)];
            }
            return reselt;
        }
    }
}