using Subs.Data.Base;
using Subs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Data
{
    public class DBService
    {
        private static SQLiteRepository<Subscription> _subscriptionRepo = default!;
        private static SQLiteRepository<SubscriptionApp> _subscriptionAppRepo = default!;

        private static bool _initialized = false;

        public static void Initialize()
        {
            if (_initialized) return;

            try
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "subs.db3");

                _subscriptionRepo = new SQLiteRepository<Subscription>(dbPath);
                _subscriptionAppRepo = new SQLiteRepository<SubscriptionApp>(dbPath);

                _initialized = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
                throw;
            }
        }
        public static SQLiteRepository<Subscription> SubscriptionRepo => _subscriptionRepo ?? throw new InvalidOperationException("DB not initialized for Subscriptions");
        public static SQLiteRepository<SubscriptionApp> SubscriptionAppRepo => _subscriptionAppRepo ?? throw new InvalidOperationException("DB not initialized for Subscription Apps");
    }
}
