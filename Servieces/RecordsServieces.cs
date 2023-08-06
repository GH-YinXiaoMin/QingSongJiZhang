using Microsoft.Extensions.Options;
using QingSongJiZhang.Models;
using QingSongJiZhang.Entity;
namespace QingSongJiZhang.Servieces;

public class RecordsServieces:BaseOperations<Record>
{
    public RecordsServieces(IOptions<DataBaseAttribute> config):base(config,config.Value.Records)
    {

    }

    public async Task<ResponseWithData<List<Record>>> GetAllRecordsAsync()
    {
        var records = await RetrieveAllAsync();
        if (records == null)
        {
            return new ResponseWithData<List<Record>>(StandardAction.Retrieve.ToString()
                , StandardModel.Record.ToString()
                , (int)StandardStatus.IsNull,new List<Record>());
        }
        else
        {
            return new ResponseWithData<List<Record>>(StandardAction.Retrieve.ToString()
                , StandardModel.Record.ToString()
                , (int)StandardStatus.Success,records);
        }
    }

}
