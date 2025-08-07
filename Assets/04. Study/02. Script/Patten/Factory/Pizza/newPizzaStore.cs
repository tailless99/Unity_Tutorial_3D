using UnityEngine;

public class newPizzaStore : PizzaStore {
    protected override Pizza CreatePizza(string type) {
        if (type.Equals("Normal")) {
            return new ChessePizza();
        }

        if (type.Equals("Special")) {
            return new BulgogiPizza();
        }

        return null;
    }
}
