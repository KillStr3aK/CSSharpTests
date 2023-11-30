namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;

    public class PlayerCache<T> : Dictionary<int, T>
    {
        public T this[CCSPlayerController controller]
        {
            get
            {
                if (base.TryGetValue(controller.UserId!.Value, out T? value))
                {
                    return value;
                }

                return default(T)!;
            }

            set { this[controller.UserId!.Value] = value; }
        }

        public bool ContainsPlayer(CCSPlayerController player)
        {
            return base.ContainsKey(player.UserId!.Value);
        }

        public bool RemovePlayer(CCSPlayerController player)
        {
            return base.Remove(player.UserId!.Value);
        }
    }
}
