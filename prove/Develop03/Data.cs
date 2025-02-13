public class Data
{

    private string _columnA;
    private string _columnB;
    private string _columnC;
    private string _columnD;

    private List<Data> _dataList;

    public Data()
    {
        _dataList = new List<Data>();
    }

    public Data getRandomData()
    {
        Random random = new Random();
        int index = random.Next(_dataList.Count);
        return _dataList[index];
    }

    public string GetColumnA()
    {
        return _columnA;
    }

    public string GetColumnB()
    {
        return _columnB;
    }

    public string GetColumnC()
    {
        return _columnC;
    }

    public string GetColumnD()
    {
        return _columnD;
    }


    public void LoadData(string filename)
    { 
        var lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            var columns = line.Split(',', 4); // need to add the 4 otherwise the text gets split a bunch
            var dataObject = new Data
            {
                _columnA = columns[0],
                _columnB = columns[1],
                _columnC = columns[2],
                _columnD = columns[3],
            };
            _dataList.Add(dataObject);
        }
    }

}