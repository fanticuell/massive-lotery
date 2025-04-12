using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;

namespace FotruneWheel.Classes
{
    public class Connection
    {
        public static SQLiteDataReader QueryLite(string query)
        {
            try
            {
                SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source=|DataDirectory|lotery.db");
                SQLiteCommand SQLiteCommand = new SQLiteCommand(query, SQLiteConnection);
                SQLiteConnection.Open();
                SQLiteDataReader reader = SQLiteCommand.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        public static void LoadPrizes(List<Classes.Prizes> prizes)
        {
            prizes.Clear();
            string str = "select * from prizes";
            var sqlite = QueryLite(str);
            while (sqlite.Read())
            {
                prizes.Add(new Classes.Prizes
                    (
                    Convert.ToInt32(sqlite.GetValue(0)),
                    Convert.ToString(sqlite.GetValue(1)),
                    Convert.ToString(sqlite.GetValue(2)),
                    Convert.ToString(sqlite.GetValue(3)),
                    Convert.ToString(sqlite.GetValue(4)),
                     Convert.ToString(sqlite.GetValue(5)),
                    Convert.ToString(sqlite.GetValue(6))));
            }
            sqlite.Close();
        }

        public static void LoadGroupPrizes(List<Classes.groupPrizes> groupPrizes)
        {
            groupPrizes.Clear();
            string str = "select * from groupPrizes";
            var sqlite = QueryLite(str);
            while (sqlite.Read())
            {
                groupPrizes.Add(new Classes.groupPrizes
                    (
                    Convert.ToInt32(sqlite.GetValue(0)),
                    Convert.ToString(sqlite.GetValue(1)),
                    Convert.ToString(sqlite.GetValue(2)),
                    Convert.ToString(sqlite.GetValue(3)),
                    Convert.ToString(sqlite.GetValue(4)),
                      Convert.ToString(sqlite.GetValue(5)),
                    Convert.ToString(sqlite.GetValue(6))));
            }
            sqlite.Close();
        }

        public static void LoadShares(List<Classes.Shares> shares)
        {
            shares.Clear();
            string str = "select * from shares";
            var sqlite = QueryLite(str);
            while (sqlite.Read())
            {
                shares.Add(new Classes.Shares
                    (
                    Convert.ToInt32(sqlite.GetValue(0)),
                    Convert.ToString(sqlite.GetValue(1)),
                    Convert.ToString(sqlite.GetValue(2)),
                    Convert.ToString(sqlite.GetValue(3)),
                    Convert.ToString(sqlite.GetValue(4)),
                    Convert.ToString(sqlite.GetValue(5)),
                       Convert.ToString(sqlite.GetValue(6)),
                     Convert.ToString(sqlite.GetValue(7)),
                      Convert.ToString(sqlite.GetValue(9)),
                    Convert.ToString(sqlite.GetValue(12))));
            }
            sqlite.Close();
        }

        public static void LoadUsers(List<Classes.Users> users)
        {
            users.Clear();
            string str = "select * from users";
            var sqlite = QueryLite(str);
            while (sqlite.Read())
            {
                users.Add(new Classes.Users
                    (
                    Convert.ToInt32(sqlite.GetValue(0)),
                    Convert.ToString(sqlite.GetValue(1)),
                    Convert.ToString(sqlite.GetValue(2)),
                    Convert.ToString(sqlite.GetValue(3))));
            }
            sqlite.Close();
        }

        public static void LoadSharesCurrent(List<Pages.InformationPage.CurrentShares> currentShares)
        {
            currentShares.Clear();
            string str = "select sheetNumber, count(sheetNumber) as count from shares where freeze ='0' group by sheetNumber";
            var sqlite = QueryLite(str);
            while (sqlite.Read())
            {
                currentShares.Add(new Pages.InformationPage.CurrentShares
                    (
                    Convert.ToString(sqlite.GetValue(0)),
                    Convert.ToString(sqlite.GetValue(1))
                    ));
            }
            sqlite.Close();
        }

        public static void AddWinnerSecondPrize(string unique_number)
        {
            string str = "update `shares` set `win`='1',`freeze`='10' where `unique_number`='" + unique_number + "'";
            var sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void FreezeAllShareSecondPrize(string sheetNumber)
        {
            string str = "update `shares` set `freeze`='11' where `sheetNumber`='" + sheetNumber + "' and `win`='0'";
            var sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void FreezeOneShareSecondPrize(string unique_number,string number)
        {
            string str = "update `shares` set `freeze`='"+number+"' where `unique_number`='" + unique_number + "'";
            var sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void FreezeShareFirstPrize(string unique_number, string sheetNumber)
        {
            string str = "update `shares` set `win`='1',`freeze`='10' where `unique_number`='" + unique_number+"'";
            var sqlite = QueryLite(str);
            sqlite.Close();
            str = "update `shares` set `freeze`='11' where `sheetNumber`='" + sheetNumber + "' and `win`='0'";
            sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void FreezeShareThirdPrize(string unique_number, string sheetNumber)
        {
            string str = "update `shares` set `win`='1',`freeze`='10' where `unique_number`='" + unique_number + "'";
            var sqlite = QueryLite(str);
            sqlite.Close();
            str = "update `shares` set `freeze`='12' where `sheetNumber`='" + sheetNumber + "' and `win`='0'";
            sqlite = QueryLite(str);
            sqlite.Close();
        }



        public static void AddWinner(Classes.Winners winners,string prize_category,string number_prize)
        {
            string str = "INSERT INTO `winners` (`sheetNumber`,`fio`,`post`,`departament`,`prize`,`prizeGroup`,`winShare`,`number`,`nrz`,`series`) values ('" + winners.sheetNumber + "','" + winners.surname + "','" + winners.post + "','" + winners.departament + "','" + winners.prize + "','" + winners.prizeID + "','" + winners.winShare+ "','" + winners.number + "','" + winners.nrz + "','" + winners.series + "');";
            var sqlite = QueryLite(str);
            sqlite.Close();
            str = "update `shares` set `winPrizeCategory`='"+ prize_category + "',`win_number_prize`='"+ number_prize +"' where `unique_number`='" + winners.winShare + "'";
            sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void DeleteWinners()
        {
            string str = "update `shares` set `win`= '0', `freeze`='0', `approved`='0'";
            var sqlite = QueryLite(str);
            sqlite.Close();
            str = "delete from winners";
            sqlite = QueryLite(str);
            sqlite.Close();
            str = "update `shares` set `winPrizeCategory`= '', `win_number_prize`=''";
            sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void Approved()
        {
            string str = "update `shares` set `approved`='1'";
            var sqlite = QueryLite(str);
            sqlite.Close();
        }

        public static void LoadWinners(List<Winners> winners)
        {
            winners.Clear();
            string str = "select * from winners";
            var sqlite = QueryLite(str);
            if (sqlite != null)
            {
                while (sqlite.Read())
                {
                    winners.Add(new Winners
                        (
                        Convert.ToInt32(sqlite.GetValue(0)),
                        Convert.ToString(sqlite.GetValue(1)),
                        Convert.ToString(sqlite.GetValue(2)),
                        Convert.ToString(sqlite.GetValue(3)),
                        Convert.ToString(sqlite.GetValue(4)),
                        Convert.ToString(sqlite.GetValue(5)),
                        Convert.ToString(sqlite.GetValue(6)),
                        Convert.ToString(sqlite.GetValue(7)),
                           Convert.ToString(sqlite.GetValue(8)),
                             Convert.ToString(sqlite.GetValue(9)),
                        Convert.ToString(sqlite.GetValue(10))
                        ));
                }
            }
            sqlite.Close();
        }

        public static void LoadDeps(List<Classes.Departament> departaments)
        {
            departaments.Clear();
            string str = "select departament from winners group by departament";
            var sqlite = QueryLite(str);
            while (sqlite.Read())
            {
                departaments.Add(new Departament
                    (
                    Convert.ToString(sqlite.GetValue(0))
                    ));
            }
            sqlite.Close();
        }
    }
}
