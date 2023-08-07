using HotChocolate.Execution.Processing;
using Microsoft.Extensions.Options;
using QingSongJiZhang.Entity;
using QingSongJiZhang.Models;
using QingSongJiZhang.Servieces;


namespace QingSongJiZhang.Port;


public class Query
{
    private readonly RecordsServieces _recordsServieces;

    public Query(RecordsServieces recordsServieces)
    {
        _recordsServieces = recordsServieces;
    }

    [GraphQLDescription("获取所有records")]
    public async Task<ResponseWithData<List<Record>>> FetchAllRecords()
    {
        return await _recordsServieces.GetAllRecordsAsync();
    }

}
