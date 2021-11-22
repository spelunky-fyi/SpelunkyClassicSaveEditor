using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace SpelunkyClassicSaveEditor
{
    class GameMakerHighScore
    {
        public ulong score;
        public string name;

        public static string HIGHSCORE_REGISTRY = "HKEY_CURRENT_USER\\Software\\Game Maker\\Scores\\834524";
        public static int OFFSET_START = 35;


        public GameMakerHighScore(ulong score, string name)
        {
            this.score = score;
            this.name = name;
        }

        public static GameMakerHighScore FromRegistry(string rank)
        {
            string value = (string)Registry.GetValue(GameMakerHighScore.HIGHSCORE_REGISTRY, rank, null);
            return GameMakerHighScore.FromEncoded(value);
        }

        public void SaveToRegistry(string rank)
        {
            Registry.SetValue(GameMakerHighScore.HIGHSCORE_REGISTRY, rank, this.EncodeForRegistry());
        }

        public static byte[] EncodedStringToByteArray(string hex)
        {

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select((x, idx) =>
                             {
                                 string byteChar = hex.Substring(x, 2);
                                 int digit1 = (int)byteChar[0] - 65;
                                 int digit2 = (int)byteChar[1] - 65;
                                 int numericValue = digit1 * 16 + digit2;
                                 numericValue = GameMakerHighScore.Mod(numericValue + (GameMakerHighScore.OFFSET_START - idx), 256);
                                 return (byte)numericValue;
                             })
                             .ToArray();
        }

        public static int Mod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }

        public static string ByteArrayToEncodedString(byte[] bytes)
        {

            string[] shiftedBytes = Enumerable.Range(0, bytes.Length)
                .Select(x =>
                {
                    var shiftedValue = GameMakerHighScore.Mod(bytes[x] - (GameMakerHighScore.OFFSET_START - x), 256);
                    var digit2 = GameMakerHighScore.Mod(shiftedValue, 16);
                    var digit1 = ((shiftedValue - digit2) / 16);
                    return "" + (char)(digit1 + 65) + (char)(digit2 + 65);
                })
                .ToArray();

            return String.Join("", shiftedBytes);
        }

        public static GameMakerHighScore FromEncoded(string encoded)
        {
            var bytes = GameMakerHighScore.EncodedStringToByteArray(encoded);
            // This is technically 16 bytes but the score is never
            // that big and this lets us just use a long for storage.
            var score = BitConverter.ToUInt64(bytes.Take(8).ToArray(), 0);
            var name = System.Text.Encoding.ASCII.GetString(bytes.Skip(16).ToArray());

            System.Diagnostics.Debug.Print("Name: {0}, Score: {1}: Registry: {2}", name, score, encoded);
            return new GameMakerHighScore(score, name);
        }

        public string EncodeForRegistry()
        {
            var scoreBytes = BitConverter.GetBytes(this.score);
            // Highscore assumes a 16byte int but we're only using an 8 byte int. Just pad
            // the additional bytes
            Array.Resize(ref scoreBytes, 16);
            var bytes = scoreBytes.Concat(System.Text.Encoding.ASCII.GetBytes(this.name)).ToArray();
            return ByteArrayToEncodedString(bytes);
        }
    }
}
