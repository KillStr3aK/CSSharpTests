namespace CSSharpTests
{
    using CounterStrikeSharp.API.Core;

    public class PlayerCache<T> : Dictionary<int, T>
    {
        public T this[CCSPlayerController controller]
        {
            get
            {
                if (base.TryGetValue(controller.Slot, out T? value))
                {
                    return value;
                }

                return default(T)!;
            }

            set { this[controller.Slot] = value; }
        }

        public bool ContainsPlayer(CCSPlayerController player)
        {
            return base.ContainsKey(player.Slot);
        }

        public bool RemovePlayer(CCSPlayerController player)
        {
            return base.Remove(player.Slot);
        }
    }
}
