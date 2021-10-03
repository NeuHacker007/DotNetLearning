using System;
using System.Linq.Expressions;

namespace ResponsibilityChainPattern
{
    /// <summary>
    /// 1. 责任链模式：逻辑封装和转移
    /// 2. 框架设计中的各种责任链模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Mock a leave request process");

                ApplyContext context = new ApplyContext()
                {
                    Id = 1,
                    Name = "Ivan",
                    Hour = 100,
                    Description = "leave",
                    AuditRemark = "",
                    AuditResult = false
                };

                {  // 1. 初级开发
                   //          // 所有逻辑都写在上端

                    //          // 首先是项目经理审批

                    //          if (context.Hour <= 8)
                    //          {
                    //              context.AuditResult = true;
                    //              context.AuditRemark = "Enjoy";
                    //          }
                    //          else
                    //          {
                    //              // 找项目经理审批
                    //              if (context.Hour <= 16)
                    //              {
                    //                  context.AuditResult = true;
                    //                  context.AuditRemark = "Enjoy";
                    //              }
                    //          }


                }

                // 2. 中级开发  知道封装了   把逻辑封装到对象里面去 而且知道使用父类 抽象
                //    缺乏远见， 系统还不够扩展，对系统设计缺乏概念， 没有长远考虑
                {
                    AbstractAuditor pm = new PM()
                    {
                        Name = "Ivan"
                    };

                    pm.Audit(context);
                    if (!context.AuditResult)
                    {
                        AbstractAuditor charger = new Charge()
                        {
                            Name = "Eva"
                        };

                        charger.Audit(context);
                        //时间更长呢，或者更多角色
                    }
                }

                {
                    // 生活中怎么样呢 我找项目经理， 经理不通过， 找主管
                    AbstractAuditor pm = new PM()
                    {
                        Name = "Ivan"
                    };

                    pm.Audit(context);
                    //      if (!context.AuditResult)
                    //      {
                    //          AbstractAuditor charger = new Charge()
                    //          {
                    //              Name = "Eva"
                    //          };

                    //          charger.Audit(context);
                    //          //时间更长呢，或者更多角色
                    //          if (!context.AuditResult)
                    //          {
                    //              AbstractAuditor manager = new Manager()
                    //              {
                    //                  Name = "Elena"
                    //              };

                    //              manager.Audit(context);
                    //              if (!context.AuditResult)
                    //              {
                    //                  AbstractAuditor ceo = new CEO()
                    //                  {
                    //                      Name = "Recheal"
                    //                  };

                    //                  ceo.Audit(context);
                    //              }
                    //          }
                    //      }
                }

                {

                    AbstractAuditor pm = new PM()
                    {
                        Name = "Ivan"
                    };
                    AbstractAuditor charger = new Charge()
                    {
                        Name = "Eva"
                    };
                    AbstractAuditor manager = new Manager()
                    {
                        Name = "Elena"
                    };
                    AbstractAuditor chief = new Chief()
                    {
                        Name = "jack"
                    };
                    AbstractAuditor ceo = new CEO()
                    {
                        Name = "Recheal"
                    };

                    //  pm.SetNext(charger);
                    //  charger.SetNext(manager);
                    //  manager.SetNext(chief);
                    //  chief.SetNext(ceo);

                    pm.SetNext(manager);
                    manager.SetNext(ceo); //可以随意调整顺序及流程

                    // 把环节初始化，把流程配置都转移到一个builder里面去
                    pm.SetNext(charger).SetNext(manager).SetNext(ceo).Audit(context);

                }


                if (context.AuditResult)
                {
                    Console.WriteLine("Vocation Approved");
                }
                else
                {
                    Console.WriteLine("Resign");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
