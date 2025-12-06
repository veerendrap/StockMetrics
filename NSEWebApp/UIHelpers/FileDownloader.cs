using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSEWebApp.UIHelpers
{

    public class FileDownloader
    {
        private readonly HttpClient _httpClient;

        public FileDownloader()
        {
            _httpClient = new HttpClient();
        }

        public string fileName = "";
        public string filePath = "";

        public async Task DownloadFileAsync(string fileUrl, string saveFolderPath)
        {
            // Create the target folder if it doesn't exist
            Directory.CreateDirectory(saveFolderPath);

            // Get the file name from the URL
            fileName = Path.GetFileName(new Uri(fileUrl).AbsolutePath);
            filePath = Path.Combine(saveFolderPath, fileName);

            using (var response = await _httpClient.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }


            try
            {
                if (filePath.ToLower().EndsWith(".zip"))
                {
                    ZipFile.ExtractToDirectory(filePath, saveFolderPath);
                }
            }
            catch (Exception) { }
        }

        public DataTable ReadCsvFile(string csvFilePath)
        {
            if (!File.Exists(csvFilePath)) return null;

            DataTable dtCsv = new DataTable();
            string Fulltext;

            using (StreamReader sr = new StreamReader(csvFilePath))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(','); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < rowValues.Count(); j++)
                                {
                                    dtCsv.Columns.Add(rowValues[j].Trim()); //add headers  
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                    }
                }
            }
            return dtCsv;
        }

    }
}
