using IndiaCensusDataDemo.DataDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        // Dictionary<string, StateCodeDataDAO> datamap;
        Dictionary<string, CensusDataDAO> censusState;
        //Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDataDAO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            try
            {
                //datamap = new Dictionary<string, StateCodeDataDAO>();
                censusState = new Dictionary<string, CensusDataDAO>();
                censusData = GetCensusData(csvFilePath, dataHeaders);
                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
                    }
                    string[] coloumn = data.Split(',');
                    //if (csvFilePath.Contains("IndiaStateCode.csv"))
                    //    datamap.Add(coloumn[1], new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3]));
                    if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                        censusState.Add(coloumn[1], new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3]));
                }
                return censusState;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }

    }
}