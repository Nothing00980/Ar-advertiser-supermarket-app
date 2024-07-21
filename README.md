# AR Advertiser

AR Advertiser is a mobile application designed for small supermarkets to enhance the shopping experience and streamline operations. Developed using Unity, this app allows users to scan product barcodes, add items to their cart, and complete purchases seamlessly. The backend is powered by Node.js, MongoDB Atlas, and integrates Vuforia Engine and Twilio for additional functionalities.

## Features

- **Barcode Scanning:** Uses Vuforia Engine for efficient barcode scanning.
- **Product Details:** Displays detailed product information, including weight in grams, vegan, and animal cruelty-free status.
- **Cart Management:** Allows users to add, remove, and update products in their cart.
- **Checkout and E-Bill Generation:** Secure payment processing and electronic bill generation.
- **Authentication System:** Secure login via email or mobile OTP verification using Twilio.
- **Session Management:** Maintains user sessions with token-based authentication.
- **Order History:** View and manage past purchases.

## Screenshots -- 

## Technologies Used

- **Frontend:** Unity
- **Backend:** Node.js
- **Database:** MongoDB Atlas
- **Authentication:** Twilio for OTP verification
- **AR Functionality:** Vuforia Engine

## Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/AR-Advertiser.git
    ```

2. **Navigate to the project directory:**
    ```bash
    cd AR-Advertiser
    ```

3. **Install backend dependencies:**
    ```bash
    cd backend
    npm install
    ```

4. **Set up environment variables:**
    - Create a `.env` file in the `backend` directory.
    - Add the following environment variables:
      ```env
      MONGODB_URI=your_mongodb_uri
      JWT_SECRET=your_jwt_secret
      TWILIO_ACCOUNT_SID=your_twilio_account_sid
      TWILIO_AUTH_TOKEN=your_twilio_auth_token
      TWILIO_PHONE_NUMBER=your_twilio_phone_number
      ```

5. **Start the backend server:**
    ```bash
    npm start
    ```

6. **Open the Unity project:**
    - Open Unity Hub and add the `frontend` folder as a new project.
    - Ensure all necessary packages are installed.
    - Build and run the project on your preferred platform.

## Usage

- **User Registration and Login:** Users can register and log in using their email or mobile number. OTP verification ensures secure access.
- **Product Scanning:** Use the app to scan product barcodes and view detailed information.
- **Cart Management:** Add products to your cart, update quantities, and proceed to checkout.
- **Checkout:** Complete the purchase and receive an electronic bill.

## API Endpoints

### Authentication

- **POST /api/auth/register:** Register a new user.
- **POST /api/auth/login:** Log in an existing user.
- **POST /api/auth/verify-otp:** Verify OTP for login.

### Products

- **GET /api/products:** Retrieve all products.
- **GET /api/products/:id:** Retrieve a specific product by ID.

### Cart

- **POST /api/cart:** Add a product to the cart.
- **PUT /api/cart/:id:** Update product quantity in the cart.
- **DELETE /api/cart/:id:** Remove a product from the cart.

### Orders

- **POST /api/orders:** Create a new order.
- **GET /api/orders:** Retrieve all orders for a user.
- **GET /api/orders/:id:** Retrieve a specific order by ID.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for review.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or suggestions, please contact yuvrajbhati00980@gmail.com.

## Contributors - 
Myself - Yuvraj Bhati 
YashDeepVerma -- 

