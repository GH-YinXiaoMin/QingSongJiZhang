using HotChocolate.Execution.Processing;
using Microsoft.Extensions.Options;
using QingSongJiZhang.Entity;
using QingSongJiZhang.Models;
using QingSongJiZhang.Servieces;

namespace QingSongJiZhang.Port;

public class Mutation
{
    private readonly RecordsServieces _recordsServieces;
    public Mutation(IOptions<DataBaseAttribute> config)
    {
        _recordsServieces = new RecordsServieces(config);
    }

    public async Task<Response> CreatOneRecord(RecordWithoutId record)
    {
        return await _recordsServieces.CreateOneRecord(record);
    }

}
