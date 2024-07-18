using helloworld.models;

namespace helloworld.controller{
    public class Week3Controller{
        public string targetOutput (int[] n, int t){
            int[] num = n;
            int target = t;
            bool breakLoop = false;
            bool completeWithBreak = false;
            string output = "";
            string outputFormat = "";
            for (int i = 0; i<num.Length; i++){
                int j = i + 1;
                while (j<num.Length){
                    int total = num[i] + num [j];
                    if (total == target){
                        breakLoop = true;
                        outputFormat = ($"Index{i}={num[i]}, Index{j}={num[j]}");
                        break;
                    }
                    j++;
                }
                if (breakLoop){
                    completeWithBreak = true;
                    break;
                }
            }
            if (completeWithBreak){
                output = outputFormat;
            }
            else {
                output = "No index found to match the target";
            }
            return output;
        }
    }
}