using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

//XMLファイルに保存するオブジェクトのためのクラス
public class Measure
{
    public string Name;
    public int Number;
    public string Message;
}

namespace Makexml
{
    internal class Program
    {
        static int Main(string[] args)
        {

            // 引数チェック
            if (args.Length != 1)
            {
                Console.Write("引数の数がおかしいです\n");
                Console.ReadLine();
                return -1;
            }
            //保存先のファイル名
            string fileName = (string)args[0];

            //保存するクラス(SampleClass)のインスタンスを作成
            Measure obj = new Measure();
            obj.Name = Path.ChangeExtension(fileName, null);
            obj.Message = "テストです。";
            obj.Number = 123;

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer =
                new System.Xml.Serialization.XmlSerializer(typeof(Measure));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                fileName, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, obj);
            //ファイルを閉じる
            sw.Close();

            Console.WriteLine("This is a piece of code");
            Console.ReadLine();
            return 0;
        }
    }
}
