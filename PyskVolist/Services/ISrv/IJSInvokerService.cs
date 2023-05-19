using System;
namespace PyskVolist.Services.ISrv
{

    public interface IJSInvokerService
	{
        public void Eval(string js);

        public string? rEval(string js);

        public Task aEval(string js);

        public void vEval(string js);
    }
}

