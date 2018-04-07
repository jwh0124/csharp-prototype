using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SAMSVX.Console.NH.NonExcutive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Developer\Desktop\Agent\[NH]\Test\test.dat";
            string savePath = @"C:\Users\Developer\Desktop\Agent\[NH]\Test\test1.dat";
            int counter = 0;
            
            // 파일 읽어오기
            string[] textValue = File.ReadAllLines(path,Encoding.Default);
            StreamWriter sw = new StreamWriter(savePath, true, Encoding.Default);
            

            // 파일 읽어오기 예외처리
            // 파일이 있는데 읽기 전용 (IOException)
            // 경로 이름이 너무 긴 경우 (PathTooLongException)
            // 디스크가 꽉 찬 경우(IOException)



            // 파일 데이터 자르기
            for (int i = 0; i < textValue.Length; i++)
            {
                string line = textValue[i].ToString();
                string[] info = line.Split('/');
                string seq = info[0].ToString();
                string empNm = info[1].ToString();
                string compNm = info[2].ToString();
                string deptNm = info[3].ToString();
                string posiNm = info[4].ToString();
                


                // 한줄씩 데이터 작성
                sw.WriteLine(textValue[i]);
                
            }

            sw.Close();
        }
    }
}
