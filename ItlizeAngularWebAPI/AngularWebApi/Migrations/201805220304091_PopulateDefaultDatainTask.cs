using System;

namespace AngularWebApi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDefaultDatainTask : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('DYR',145,'Itlize1','task1','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('BF',213,'Itlize2','task2','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('BF',212,'Itlize3','task3','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('BF',210,'Itlize4','task4','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('BF',205,'Itlize5','task5','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('DYR',142,'Itlize6','task6','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('DYR',141,'Itlize7','task7','" + DateTime.Now + "','Follow-up')");
            Sql("insert into Tasks (QuoteType,QuoteNumber,Contact,Task,DueDate,TaskType) values ('DYR',135,'Itlize8','task8','" + DateTime.Now + "','Follow-up')");
        }

        public override void Down()
        {
        }
    }
}
