namespace todo_clean.api.shared.results
{
    public class CustomSuccessResult : CustomResultBase
    {
        public object result { get; set; } = null;

        public CustomSuccessResult(object result)
        {
            this.success = true;
            this.result = result;
        }
    }
}