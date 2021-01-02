using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Web;

namespace MOCAPP.MOC_COMMON
{
    public class Common
    {



        public  List<Models.MOC_Model.New_MOC_Model> Get_MocRecord()
        {
            string queryString = "Sp_getMocRecord";
            try
            {
                List<Models.MOC_Model.New_MOC_Model> returnModel = new List<Models.MOC_Model.New_MOC_Model>();

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

                OracleCommand commed4 = new OracleCommand(queryString, connection);
                OracleDataAdapter adpter4 = new OracleDataAdapter(commed4);
                commed4.CommandType = CommandType.StoredProcedure;
                commed4.Parameters.Add("p_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
                commed4.Parameters.Add(new OracleParameter("p_flag", OracleType.Int32, 10)).Value = 1;
                DataSet ds = new DataSet();
                adpter4.Fill(ds);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            returnModel.Add(new Models.MOC_Model.New_MOC_Model()
                            {

                                MOC_Number = Convert.ToString(dr["MOC_Number"]),
                                Station = Convert.ToString(dr["Station"]),
                                Department = Convert.ToString(dr["Department"]),
                                Type_of_Change = Convert.ToString(dr["Type_of_Change"]),
                                Description = Convert.ToString(dr["Description"]),
                               Periodicity_date_from = Convert.ToString(dr["Periodicity_date_from"]),
                                Periodicity_date_To=  Convert.ToString(dr["Periodicity_date_To"]),
                                Status = Convert.ToString(dr["Status"]),
                                Remark = Convert.ToString(dr["Remark"]),



                            }
                          );
                        }
                        return returnModel;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
                //return null;
            }
            return null;

        }

        public List<Models.MOC_Model.New_MOC_Model> Get_MocRecordfilter(Models.MOC_Model.New_MOC_Model obj)
        {
            string queryString = "Sp_getMocRecord";
            try
            {
                List<Models.MOC_Model.New_MOC_Model> returnModel = new List<Models.MOC_Model.New_MOC_Model>();

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

                OracleCommand commed4 = new OracleCommand(queryString, connection);
                OracleDataAdapter adpter4 = new OracleDataAdapter(commed4);
                commed4.CommandType = CommandType.StoredProcedure;
                commed4.Parameters.Add("p_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
                commed4.Parameters.Add(new OracleParameter("p_flag", OracleType.Int32, 10)).Value = 4;
                commed4.Parameters.Add(new OracleParameter("p_fromdate", OracleType.VarChar, 20)).Value = obj.Periodicity_date_from;
                commed4.Parameters.Add(new OracleParameter("p_todate", OracleType.VarChar, 20)).Value = obj.Periodicity_date_To;

                DataSet ds = new DataSet();
                adpter4.Fill(ds);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            returnModel.Add(new Models.MOC_Model.New_MOC_Model()
                            {

                                MOC_Number = Convert.ToString(dr["MOC_Number"]),
                                Station = Convert.ToString(dr["Station"]),
                                Department = Convert.ToString(dr["Department"]),
                                Type_of_Change = Convert.ToString(dr["Type_of_Change"]),
                                Description = Convert.ToString(dr["Description"]),
                                Periodicity_date_from = Convert.ToString(dr["Periodicity_date_from"]),
                                Periodicity_date_To = Convert.ToString(dr["Periodicity_date_To"]),
                                Status = Convert.ToString(dr["Status"]),
                                Remark = Convert.ToString(dr["Remark"]),



                            }
                          );
                        }
                        return returnModel;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
                //return null;
            }
            return null;

        }


        public List<Models.MOC_Model.New_MOC_Model> Get_MocRecordView(string Mocnumber)
        {
            string queryString = "Sp_getMocRecord";
            try
            {
                List<Models.MOC_Model.New_MOC_Model> returnModel = new List<Models.MOC_Model.New_MOC_Model>();

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

                OracleCommand commed4 = new OracleCommand(queryString, connection);
                OracleDataAdapter adpter4 = new OracleDataAdapter(commed4);
                commed4.CommandType = CommandType.StoredProcedure;
                commed4.Parameters.Add("p_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;

                commed4.Parameters.Add(new OracleParameter("p_flag", OracleType.Int32, 10)).Value = 3;
                commed4.Parameters.Add(new OracleParameter("p_moc_no", OracleType.VarChar, 10)).Value = Mocnumber;

                DataSet ds = new DataSet();
                adpter4.Fill(ds);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            returnModel.Add(new Models.MOC_Model.New_MOC_Model()
                            {

                                MOC_Number = Convert.ToString(dr["MOC_Number"]),
                                Station = Convert.ToString(dr["Station"]),
                                Department = Convert.ToString(dr["Department"]),
                                Type_of_Change = Convert.ToString(dr["Type_of_Change"]),
                                Description = Convert.ToString(dr["Description"]),
                                Periodicity_date_from = Convert.ToString(dr["Periodicity_date_from"]),
                                Periodicity_date_To = Convert.ToString(dr["Periodicity_date_To"]),
                                // Status=  Convert.ToString(dr["Observation"]),
                                //Remark= Convert.ToDateTime(dr["Observation"]),



                            }
                          );
                        }
                        return returnModel;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
                //return null;
            }
            return null;

        }

        public List<Models.MOC_Model.New_MOC_Model> Get_MocRecordEdit( string Mocnumber)
        {
            string queryString = "Sp_getMocRecord";
            try
            {
                List<Models.MOC_Model.New_MOC_Model> returnModel = new List<Models.MOC_Model.New_MOC_Model>();

                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

                OracleCommand commed4 = new OracleCommand(queryString, connection);
                OracleDataAdapter adpter4 = new OracleDataAdapter(commed4);
                commed4.CommandType = CommandType.StoredProcedure;
                commed4.Parameters.Add("p_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;

                commed4.Parameters.Add(new OracleParameter("p_flag", OracleType.Int32, 10)).Value = 2;
                commed4.Parameters.Add(new OracleParameter("p_moc_no", OracleType.VarChar, 10)).Value = Mocnumber;

                DataSet ds = new DataSet();
                adpter4.Fill(ds);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            returnModel.Add(new Models.MOC_Model.New_MOC_Model()
                            {

                                MOC_Number = Convert.ToString(dr["MOC_Number"]),
                                Station = Convert.ToString(dr["Station"]),
                                Department = Convert.ToString(dr["Department"]),
                                Type_of_Change = Convert.ToString(dr["Type_of_Change"]),
                                Description = Convert.ToString(dr["Description"]),
                                Periodicity_date_from = Convert.ToString(dr["Periodicity_date_from"]),
                                Periodicity_date_To = Convert.ToString(dr["Periodicity_date_To"]),

                                Status = Convert.ToString(dr["Status"]),
                                Remark = Convert.ToString(dr["Remark"]),



                            }
                          );
                        }
                        return returnModel;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
                //return null;
            }
            return null;

        }

       

        public int UpdateMoc(Models.MOC_Model.New_MOC_Model obj)
        {


            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

            try
            {
                var querystr1 = "SP_MOC_INS";
                using (OracleCommand command1 = new OracleCommand(querystr1, connection))
                {
                    command1.Connection.Open();

                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.Add(new OracleParameter("p_MOC_NUMBER", OracleType.VarChar, 200)).Value = obj.MOC_Number;
                    command1.Parameters.Add(new OracleParameter("p_Description", OracleType.VarChar, 200)).Value = obj.Description;
                    command1.Parameters.Add(new OracleParameter("p_Station", OracleType.VarChar, 200)).Value = obj.Station;


                    command1.Parameters.Add(new OracleParameter("p_Type_of_Change", OracleType.VarChar, 100)).Value = obj.Type_of_Change;
                    command1.Parameters.Add(new OracleParameter("p_Department", OracleType.VarChar, 1000)).Value = obj.Department;


                    //command1.Parameters.Add(new OracleParameter("p_Identified_Tagno", OracleType.VarChar, 50)).Value = obj.Identified_Tagno;


                    //command1.Parameters.Add(new OracleParameter("p_Circuit", OracleType.VarChar, 50)).Value = obj.Circuit;
                    //command1.Parameters.Add(new OracleParameter("p_Reasons_Change", OracleType.VarChar, 1000)).Value = obj.Reasons_Change;




                    //command1.Parameters.Add(new OracleParameter("p_Impact_Change", OracleType.VarChar, 200)).Value = obj.Impact_Change;
                    //command1.Parameters.Add(new OracleParameter("p_Change_Proposed", OracleType.VarChar, 200)).Value = obj.Change_Proposed;


                    //command1.Parameters.Add(new OracleParameter("p_Hazards_Identified", OracleType.VarChar, 100)).Value = obj.Hazards_Identified;
                    //command1.Parameters.Add(new OracleParameter("p_Arrang_mitigation", OracleType.VarChar, 1000)).Value = obj.Arrang_mitigation;


                    //command1.Parameters.Add(new OracleParameter("p_Revised_Drawings", OracleType.VarChar, 50)).Value = obj.Revised_Drawings;


                    command1.Parameters.Add(new OracleParameter("p_Periodicity_date_from", OracleType.VarChar, 50)).Value = obj.Periodicity_date_from;
                    //command1.Parameters.Add(new OracleParameter("p_Periodicity_time_from", OracleType.VarChar, 1000)).Value = obj.Periodicity_time_from;

                    command1.Parameters.Add(new OracleParameter("p_Periodicity_date_To", OracleType.VarChar, 50)).Value = obj.Periodicity_date_To;
                    //command1.Parameters.Add(new OracleParameter("p_Periodicity_time_To", OracleType.VarChar, 1000)).Value = obj.Periodicity_time_To;
                    command1.Parameters.Add(new OracleParameter("p_CreateBy", OracleType.VarChar, 50)).Value = obj.CreateBy;
                    command1.Parameters.Add(new OracleParameter("P_Remark", OracleType.VarChar, 200)).Value = obj.Remark;
                    command1.Parameters.Add(new OracleParameter("P_Status", OracleType.VarChar, 200)).Value = obj.Status;
                    command1.Parameters.Add(new OracleParameter("P_flag", OracleType.Int32, 200)).Value = 2;



                    command1.ExecuteNonQuery();
                    command1.Connection.Close();
                }
                return 1;
            }
            catch (Exception e)
            {

                return -1;
            }
            finally
            {
                //conn.Close();
                //cmd.Connection = null;
                //cmd.Parameters.Clear();
                //cmd.Dispose();
                //trans.Dispose();
            }
        }

        public int SAVE_NEWMOC(Models.MOC_Model.New_MOC_Model obj, string fileName)
        {


            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString;

            try
            {
                var querystr1 = "SP_MOC_INS";
                using (OracleCommand command1 = new OracleCommand(querystr1, connection))
                {
                    command1.Connection.Open();

                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.Add(new OracleParameter("p_Description", OracleType.VarChar, 200)).Value = obj.Description;
                    command1.Parameters.Add(new OracleParameter("p_Station", OracleType.VarChar, 200)).Value = obj.Station;


                    command1.Parameters.Add(new OracleParameter("p_Type_of_Change", OracleType.VarChar, 100)).Value = obj.Type_of_Change;
                    command1.Parameters.Add(new OracleParameter("p_Department", OracleType.VarChar, 1000)).Value = obj.Department;


                    command1.Parameters.Add(new OracleParameter("p_Identified_Tagno", OracleType.VarChar, 50)).Value = obj.Identified_Tagno;


                    command1.Parameters.Add(new OracleParameter("p_Circuit", OracleType.VarChar, 50)).Value = obj.Circuit;
                    command1.Parameters.Add(new OracleParameter("p_Reasons_Change", OracleType.VarChar, 1000)).Value = obj.Reasons_Change;


                

                    command1.Parameters.Add(new OracleParameter("p_Impact_Change", OracleType.VarChar, 200)).Value = obj.Impact_Change;
                    command1.Parameters.Add(new OracleParameter("p_Change_Proposed", OracleType.VarChar, 200)).Value = obj.Change_Proposed;


                    command1.Parameters.Add(new OracleParameter("p_Hazards_Identified", OracleType.VarChar, 100)).Value = obj.Hazards_Identified;
                    command1.Parameters.Add(new OracleParameter("p_Arrang_mitigation", OracleType.VarChar, 1000)).Value = obj.Arrang_mitigation;


                    command1.Parameters.Add(new OracleParameter("p_Revised_Drawings", OracleType.VarChar,400)).Value = fileName;


                    command1.Parameters.Add(new OracleParameter("p_Periodicity_date_from", OracleType.VarChar, 50)).Value = obj.Periodicity_date_from;
                    command1.Parameters.Add(new OracleParameter("p_Periodicity_time_from", OracleType.VarChar, 1000)).Value = obj.Periodicity_time_from;

                    command1.Parameters.Add(new OracleParameter("p_Periodicity_date_To", OracleType.VarChar, 50)).Value = obj.Periodicity_date_To;
                    command1.Parameters.Add(new OracleParameter("p_Periodicity_time_To", OracleType.VarChar, 1000)).Value = obj.Periodicity_time_To;
                    command1.Parameters.Add(new OracleParameter("p_CreateBy", OracleType.VarChar, 50)).Value = obj.CreateBy;
                    command1.Parameters.Add(new OracleParameter("P_Remark", OracleType.VarChar, 200)).Value = obj.Remark;
                    command1.Parameters.Add(new OracleParameter("P_flag", OracleType.Int32, 200)).Value = 1;



                    command1.ExecuteNonQuery();
                    command1.Connection.Close();
                }
                return 1;
            }
            catch (Exception e)
            {

                return -1;
            }
            finally
            {
                //conn.Close();
                //cmd.Connection = null;
                //cmd.Parameters.Clear();
                //cmd.Dispose();
                //trans.Dispose();
            }
        }


    }
}