using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    IHelper helper = new SqlServerHelper();
                    helper.Add<Program>();
                    helper.Delete<Program>();
                    helper.Query<Program>();
                    helper.Update<Program>();
                }

                {
                    IHelper helper = new OracleHelper();
                    helper.Add<Program>();
                    helper.Delete<Program>();
                    helper.Query<Program>();
                    helper.Update<Program>();
                }

                {
                    IHelper helper = new MysqlHelper();
                    helper.Add<Program>();
                    helper.Delete<Program>();
                    helper.Query<Program>();
                    helper.Update<Program>();
                }

                {
                    //由于Redis是第三方的类库，虽然当中也有增删改查，
                    //但我们无法直接让其继承IHelper 故而无法像如下使用
                    //此时我们应当考虑适配器模式

                    //    IHelper helper = new RedisHelper();
                    //    helper.Add<Program>();
                    //    helper.Delete<Program>();
                    //    helper.Query<Program>();
                    //    helper.Update<Program>();
                }

                {
                    IHelper helper = new RedisHelperInherit();
                    helper.Add<Program>();
                    helper.Delete<Program>();
                    helper.Query<Program>();
                    helper.Update<Program>();

                    RedisHelperInherit helperInherit = new RedisHelperInherit();

                    helperInherit.AddRedis<Program>(); //强侵入性，继承导致父类有的子类必须也有
                }

                {
                    IHelper helper = new RedisHelperCombination();
                    helper.Add<Program>();
                    helper.Delete<Program>();
                    helper.Query<Program>();
                    helper.Update<Program>();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               // throw;
            }
        }
    }
}
