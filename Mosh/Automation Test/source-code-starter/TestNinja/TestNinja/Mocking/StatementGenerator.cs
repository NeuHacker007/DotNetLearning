/**
* @Project Name: $projectname$ ： StatementGenerator
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Mocking
* @Creation Time:  3/16/2018 10:43:12 AM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/16/2018 10:43:12 AM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/
using System;
using System.IO;

namespace TestNinja.Mocking
{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }

    class StatementGenerator : IStatementGenerator
    {
        public string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate = new DateTime())
        {
            var report = new HousekeeperStatementReport(housekeeperOid, statementDate);

            if (!report.HasData)
                return string.Empty;

            report.CreateDocument();

            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                string.Format("Sandpiper Statement {0:yyyy-MM} {1}.pdf", statementDate, housekeeperName));

            report.ExportToPdf(filename);

            return filename;
        }
    }
}
