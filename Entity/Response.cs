namespace QingSongJiZhang.Entity;

public class Response
{
    public string Action { get; set; }=string.Empty;
    public string Model { get;set; } = string.Empty;
    public int Status { get;set; } = 0;

    public Response(string action,string model,int status)
    {
        Action= action;
        Model= model;
        Status= status;
    }
}

public class ResponseWithData<T> : Response
{
    public T Data { get; set; }
    public ResponseWithData(string action, string model, int status, T data) : base(action, model, status)
    {
        Data = data;
    }
}

public enum StandardAction
{
    Create,
    Update, 
    Delete,
    Retrieve
}

public enum StandardModel
{
    Record
}

public enum StandardStatus
{
    Success=605,
    Failure=606,
    UnkownError=608,
    IsNull=610
}

