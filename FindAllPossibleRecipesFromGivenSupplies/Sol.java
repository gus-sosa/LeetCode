import java.util.*;
import java.util.stream.Collectors;

public class Sol {
    public static void main(String[] args) {
        var s = new Solution();
        var ingredients = new LinkedList<List<String>>();
        ingredients.add(Arrays.stream(new String[]{"yeast", "flour"}).toList());
        ingredients.add(Arrays.stream(new String[]{"bread", "meat"}).toList());
        s.findAllRecipes(new String[]{"bread", "sandwich"}, ingredients, new String[]{"yeast", "flour", "meat"});
    }
}

class Solution {
    private HashMap<String, Integer> recipes;
    private Set<String> supplies;
    private boolean[] marked;
    private boolean[] processed;
    private List<List<String>> ingredients;

    public List<String> findAllRecipes(String[] recipes, List<List<String>> ingredients, String[] supplies) {
        this.ingredients = ingredients;
        this.supplies = Arrays.stream(supplies).collect(Collectors.toSet());
        this.recipes = new HashMap<>();
        for (int i = 0; i < recipes.length; i++) {
            this.recipes.put(recipes[i], i);
        }

        marked = new boolean[recipes.length];
        processed = new boolean[recipes.length];
        for (int i = 0; i < processed.length; i++) {
            if (!processed[i]) {
                dfs(i);
            }
        }

        return Arrays.stream(recipes).filter(i -> marked[this.recipes.get(i)]).toList();
    }

    private void dfs(Integer pos) {
        if (marked[pos] || processed[pos]) {
            return;
        }
        processed[pos] = true;

        for (var ingredient :
                ingredients.get(pos)) {
            if (recipes.containsKey(ingredient)) {
                dfs(recipes.get(ingredient));
                if (!marked[recipes.get(ingredient)]) {
                    return;
                }
            } else {
                if (!supplies.contains(ingredient)) {
                    return;
                }
            }
        }
        marked[pos] = true;
    }
}