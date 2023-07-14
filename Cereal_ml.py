import pandas as pd
import numpy as np
from multiprocessing import Pool

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

# Initialize a 'choices' column to keep track of past choices
df['choices'] = 0

# Define a function to simulate a consumer choosing a cereal


def choose_cereal(df):
    # Adjust probabilities based on past choices, but reduce the weight of past choices
    probabilities = (0.95 * df['score'] + 0.05 * df['choices']) / \
        (0.95 * df['score'] + 0.05 * df['choices']).sum()
    choice = np.random.choice(df['cereal'], p=probabilities)

    # Update the 'choices' column
    df.loc[df['cereal'] == choice, 'choices'] += 1

    return choice

# Define a function to simulate multiple consumers


def simulate_consumers(n):
    return [choose_cereal(df) for _ in range(n)]


if __name__ == '__main__':
    # Create a pool of worker processes
    with Pool() as p:
        # Simulate 10000000 consumers, distributing the tasks among the worker processes
        choices = p.map(simulate_consumers, [10000000] * 4)

    # Flatten the list of choices
    choices = [choice for sublist in choices for choice in sublist]

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
