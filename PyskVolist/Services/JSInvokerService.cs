using System;
using PyskVolist.Services.ISrv;
using Microsoft.JSInterop;

namespace PyskVolist.Services
{
	public class JSInvokerService : IJSInvokerService
	{
		private IJSRuntime _js;

        public void Eval(string js)
        {
            _js.InvokeAsync<string>("eval", js);
        }

        public string? rEval(string js)
        {
            return _js.InvokeAsync<string>("eval", js).Result;
        }

        public async Task aEval(string js)
        {
            await _js.InvokeAsync<string>("eval", js);
        }

        public void vEval(string js)
        {
            _js.InvokeVoidAsync("eval", js);
        }

        public JSInvokerService(IJSRuntime jr)
		{
            _js = jr;
		}
	}
}

