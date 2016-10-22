using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.Entity.SqlServer;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;



namespace Bot_S
{
    class Program
    {
        static void Main(string[] args)
        {
            string request = Console.ReadLine();
            string[] words = request.Split(new char[] { ' ', ',', '"', '.' }, StringSplitOptions.RemoveEmptyEntries);



            using (var Data = new Skype_DataEntities())
            {
                var Req = from c in Data.Table_Request
                          select c.Request;
                for (int i = 0; i < words.Length; i++)
                {

                    var t = Req.Contains(words[i]);
                    string o = words[i];
                  
                        try
                        {
                            var re = from e in Data.Table_Request
                                     where e.Request == o
                                     select e.Index;
                            foreach (int w in re)
                            {

                                var r = from q in Data.Table_Message
                                        where q.ID == w
                                        select q.Message;
                                string P = r.First();
                                Console.WriteLine(P);
                                

                                break;
                                
                            }

                        }
                        catch (Exception)
                        {
                            return;

                        }
                       
                    
              
                }
                Console.ReadKey();
            }
        }
}
}
    
        