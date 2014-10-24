using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Orleans.Linq {
    public class PredicateSubscriptionManager<TObserver, TSource> where TObserver : IGrainObserver {
        private Dictionary<TObserver, Func<TSource, bool>> _observers = new Dictionary<TObserver, Func<TSource, bool>>();

        public void Notify(TSource value, Action<TObserver> notification) {
            var remove = new List<Action>();

            foreach (var observer in _observers.Where(o => o.Value(value))) {
                try {
                    notification((TObserver)observer.Key);
                }
                catch {
                    remove.Add(() => _observers.Remove(observer.Key));
                }
            }

            foreach (var action in remove) {
                action();
            }
        }

        public void Clear() {
            _observers.Clear();
        }

        public void Subscribe(TObserver observer, Expression<Func<TSource, bool>> expression) {
            Subscribe(observer, expression.Compile());
        }

        public void Subscribe(TObserver observer, Func<TSource, bool> predicate) {
            _observers[observer] = predicate;
        }

        public void Unsubscribe(TObserver observer) {
            _observers.Remove(observer);
        }
    }
}