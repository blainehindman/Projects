import pandas as pd
import numpy as np

# Define sales and sugar data
data = {
    'cereal': ['Froot Loops', 'Cap\'n Crunch Berries', 'Frosted Flakes', 'Apple Jacks', 'Reese\'s Puffs', 'Life', 'Fruity Pebbles', 'Cinnamon Toast Crunch', 'Honey Nut Cheerios', 'Raisin Bran', 'Raisin Bran Crunch', 'Honey Bunches of Oats', 'Lucky Charms', 'Rice Krispies Treats Cereal', 'Frosted Mini-Wheats', 'Corn Pops', 'Corn Flakes', 'Special K Red Berries'],
    'sales': [91.7, 38.3, 132.3, 40.8, 35.3, 58.1, 54.1, 105.2, 139.1, 48.9, 37.5, 111.3, 86.4, 42.1, 71.3, 23.1, 31.7, 39.4],
    'sugar': [12, 14.7, 14.7, 12, 13.3, 6, 15, 12, 12.2, 18, 19, 6, 12.9, 4, 11, 9, 2.4, 9]
}

# Create DataFrame
df = pd.DataFrame(data)

# Normalize sales and sugar data to be between 0 and 1
df['sales_norm'] = df['sales'] / df['sales'].max()
df['sugar_norm'] = df['sugar'] / df['sugar'].max()

# Assign scores, with sales counting more than sugar
df['score'] = 0.7 * df['sales_norm'] + 0.3 * df['sugar_norm']

# Define a function to simulate a consumer choosing a cereal


def choose_cereal(df):
    probabilities = df['score'] / df['score'].sum()
    choice = np.random.choice(df['cereal'], p=probabilities)
    return choice


# Simulate 10000 consumers
choices = [choose_cereal(df) for _ in range(1000000)]

# Count the number of times each cereal was chosen
choice_counts = pd.Series(choices).value_counts()

# Print all cereals and their scores, sorted by score
print("Cereal scores:")
print(df[['cereal', 'score']].sort_values(by='score', ascending=False))

# Print how often each cereal was chosen, sorted by count
print("\nCereal choices:")
print(choice_counts.sort_values(ascending=False))

# Print the top 5 cereals, sorted by how often they were chosen
print("\nTop 5 cereals:")
print(choice_counts.nlargest(5))
