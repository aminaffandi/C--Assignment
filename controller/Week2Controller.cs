using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.XPath;
using helloworld.models;

namespace helloworld.controller{
    public class Week2Controller {
        public string cns_output (Week2Model cns){
            int cns_count = cns.CnS;
            if (cns_count <= 0){
                return "";
            }
            string result = "1";
            for (int i = 0; i<cns_count; i++){
                result = NextSequence(result);
            }
            return result;
        }

        public static string NextSequence(string seq){
            // 1, 11, 21, 1211, 111221,
            StringBuilder nextseq = new StringBuilder();
            List<string> seqList = new List<string>();
            //loop thru each index
            for (int i = 0; i<seq.Length; i++){
                int counter = 1;
                // loop thru each character
                while (i + 1 < seq.Length && seq[i] == seq[i+1]){
                    counter++;
                    i++;
                }
                // counter = pronounciation (how many n), seq[i] is the value
                nextseq.Append(counter.ToString()+seq[i]);
                seqList.Add(counter.ToString()+seq[i]);
            }

            // Print each element in seqList
            Console.WriteLine($"[{string.Join(", ",seqList)}]");

            return nextseq.ToString();
        }

        public void star_output(Week2Model star){
            // if n = 4
            // first star = 1
            // second star = 3
            // third star = 5
            // fourth = 7
            // if n = 5
            // first star = 1
            // second star = 3
            // third star = 5
            // fourth star = 7
            // fift star = 9
            // each increment = 2
            // max character compared to n = increment 1
            // n = 1, max character = 1, difference = 0
            // n =2, max character = 3, difference = 1
            // n = 3, max character = 5, difference = 2
            // n = 4, max character = 7, difference = 3
            // max character = max row

            int starcount = star.StarCount; // starcount = midrow. middle row = max stars
            int maxRow = 1;
            // loop to get max character each row. Can also use n*2-1
            for (int n = 1; n < starcount; n++){
                maxRow += 2;
            }
            Console.WriteLine($"Number of maxrow = {maxRow}");

            // loop thru upper diamond including middle row
            for (int i = 1; i<=starcount; i ++){
                // assign spaces for row to centers the stars
                for (int j = 1; j <=starcount - i; j++){
                    Console.Write(" ");
                }
                // assign star at current row 
                for (int k = 1; k <= (i*2)-1; k++){
                    Console.Write("*");
                }
                // create new row
                Console.WriteLine();
            }

            // loop thru lower diamond
            for (int i = starcount-1; i >=1 ; i--){
                for (int j = 1; j <= starcount-i; j++){
                    Console.Write(" ");
                }
                for (int k = 1; k <= (i*2)-1; k++){
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}