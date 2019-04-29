class OnEnabler : TriggerComponent
{
    private void OnEnable()
    {
        InvokeAll();
    }
}
