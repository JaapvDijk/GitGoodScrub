namespace GitGoodScrub
{
    public delegate TResult CustomFunc<in T1, out TResult>(T1 arg);
}