namespace todo_clean.api.shared.results
{
    public class CustomSuccessResult : CustomResultBase
    {
        public object data { get; set; }

        public CustomSuccessResult(object data)
        {
            this.success = true;
            this.data = data;
        }
    }
}