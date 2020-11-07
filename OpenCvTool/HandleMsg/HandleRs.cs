namespace OpenCvTool.HandleMsg
{
    public class HandleRs
    {
        public HandleRs() { }
        public HandleRs(bool success, int code, string msg)
        {
            Success = success;
            Msg = msg;
        }

        public bool Success { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }

        public HandleRs SetSuccess(string msg = null)
        {
            Success = true;
            Code = 0;
            Msg = msg;
            return this;
        }

        public HandleRs SetError(int errCode, string msg = null)
        {
            Code = errCode;
            Msg = msg;
            return this;
        }
    }
}