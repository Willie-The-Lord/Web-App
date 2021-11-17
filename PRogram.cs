using System;

namespace EncryptNamespace
{
    class Encrypt
    {
        // 宣告私有欄位
        private string _letter, _code;

        // 存取 _letter 的屬性
        public string Letter {
            get {return _letter;}
            set {
                _letter = value;
            }
        }

        // 存取 _code 的屬性
        public string Code {
            get {return _code;}
            set {
                // value 必須是符合英文字母表的字串
                if (value is string && value.Length == 26)
                {
                    _code = value;
                }
                // 不符合條件不做設定，印出錯誤訊息
                else
                {
                    Console.WriteLine("密碼字串錯誤，請修改程式。");
                }
            }
        }

        // 沒有參數的建構子，建立隨機密碼表
        public Encrypt()
        {
            Letter = "abcdefghijklmnopqrstuvwxyz";
            Code = Shuffle(this.Letter);
        }

        // 有參數的的建構子，由參數建立密碼表
        public Encrypt(string newCode)
        {
            Letter = "abcdefghijklmnopqrstuvwxyz";
            Code = newCode;
        }

        // 攪亂字串順序
        string Shuffle(string s)
        {
            // 將參數字串轉換成字元陣列
            char[] s_array = s.ToCharArray();
            // 建立隨機物件
            Random r = new Random();
            // 取得字串長度
            int n = s.Length;
            // 依序攪亂字元陣列的順序
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                var v = s_array[k];
                s_array[k] = s_array[n];
                s_array[n] = v;
            }

            // 最後回傳將字元陣列合併的字串
            return new string(s_array);
        }

        // 編碼方法
        public string ToEncode(string s)
        {
            // result 為處理過程中的暫存字串
            string result = "";
            // 逐一取得字元進行處理
            foreach (char i in s)
            {
                // 判斷是否為英文小寫字母
                if (this.Letter.Contains(i.ToString()))
                {
                    result += this.Code[this.Letter.IndexOf(i)];
                }
                // 不是英文小寫字母，直接將字元附加到 result 之後
                else
                {
                    result += i;
                }
            }
            // 回傳結果
            return result;
        }

        // 解碼方法
        public string ToDecode(string s)
        {
            // 建立暫存字串
            string result = "";
            // 逐一取得字元進行處理
            foreach (char i in s)
            {
                // 判斷是否為英文小寫字母
                if (this.Letter.Contains(i.ToString()))
                {
                    result += this.Letter[this.Code.IndexOf(i)];
                }
                // 不是英文小寫字母，直接將字元附加到 result 之後
                else
                {
                    result += i;
                }
            }
            // 回傳結果
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 建立密碼物件 e
            Encrypt e = new Encrypt();
            // 印出密碼表
            Console.WriteLine(e.Code);
            // 設定測試字串
            string s1 = "There is no spoon.";
            // 印出測試字串
            Console.WriteLine(s1);
            // 進行編碼
            string s2 = e.ToEncode(s1);
            // 印出編碼後的字串
            Console.WriteLine(s2);
            // 進行解碼
            string s3 = e.ToDecode(s2);
            // 印出解碼後的字串
            Console.WriteLine(s3);
            // 設定長度不符的新密碼物件
            Encrypt e2 = new Encrypt("no");
            // 設定長度相符的新密碼物件
            Encrypt e3 = new Encrypt("qazwsxedcrfvtgbyhnujmikolp");
            // 再次進行編碼
            string s4 = e3.ToEncode(s1);
            // 印出編碼後的字串
            Console.WriteLine(s4);
            // 再次進行解碼
            string s5 = e3.ToDecode(s4);
            // 印出解碼後的字串
            Console.WriteLine(s5);
        }
    }
}
