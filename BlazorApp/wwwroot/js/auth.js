window.logoutUser = async function () {
    console.log('logoutUser function called');
    const response = await fetch('https://localhost:7130/api/auth/logout', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        credentials: 'include'
    });

    if (response.ok) {
        console.log("Logged out successfully!");
        return "Logged out successfully";
    } else {
        console.error("Logout failed.");
        return "Logout failed";
    }
};

window.loginUser = async (email, password) => {
    const response = await fetch('https://localhost:7130/api/auth/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email: email, password: password }),
        credentials: 'include'
    });

    if (response.ok) {
        const cookies = document.cookie;
        console.log("Login successful!");
        console.log(cookies);
        return { success: true };
    } else {
        console.error("Login failed.");
        return { success: false, message: 'Invalid credentials' };
    }
};
