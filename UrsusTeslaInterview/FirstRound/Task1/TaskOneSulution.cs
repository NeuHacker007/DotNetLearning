using System.Text;

namespace FirstRound
{
    public class TaskOneSulution
    {
        public string GenerateTheString(int n)
        {
            var sb = new StringBuilder();
            if (n % 2 != 0)
            {
                sb.Append('a', n);
            }
            else
            {
                sb.Append('a', n - 1);
                sb.Append('b');
            }

            return sb.ToString();
        }
    }

}
