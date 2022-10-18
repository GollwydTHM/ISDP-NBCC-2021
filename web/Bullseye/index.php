<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Bullseye</title>

        <link rel="stylesheet" href="mainStyleSheet.css">
        <script src="main.js"></script>
    </head>
    <body>
        <h1>Bullseye - Sporting Goods</h1>

        <button id="GetButton">Get Data</button>
     
        <label for="locationSelect">Location: </label>
        <select id="locationSelect">
            
        </select>  

        <label for="categoriesSelect">Categories: </label>
        <select id="categoriesSelect">
            
        </select>      
 
        <form method="POST" action="menus/cart.php" class="">
            <button id="Cart" type="submit">Look Cart</button>
        </form>

        <form method="POST" action="menus/checkorder.php" class="">
            <button id="CheckOrder" type="submit">Check Order</button>
        </form>

        <form method="POST" action="menus/Addcart.php" class="">
            <button id="AddButton" type="submit">Add to Cart</button>
        
        <table>
            <tr>
                <th>Item ID</th>
                <th>Name</th>
                <th>Category</th>
                <th>Location</th>
                <th>In Stock</th>
                <th>Quantity</th>
                
            </tr>
        </table>
        </form>

    </body>
</html>
