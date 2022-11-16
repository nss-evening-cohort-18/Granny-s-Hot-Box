export const getAllMealProducts = () => {
    return fetch('https://localhost:7245/api/MealProduct')
        .then(res => res.json())
}