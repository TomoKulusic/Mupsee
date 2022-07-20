import React, { useState } from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { Link as RouterLink } from "react-router-dom";
import { useAuth } from "../../services/useAuth";
import UserService from "../../services/userService";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";

export const LoginPage = () => {
  const [snackbar, setSnackBar] = useState(false);
  const { login } = useAuth();

  const handleSubmit = (event) => {
    event.preventDefault();

    var body = JSON.stringify({
      username: event.target.username.value,
      password: event.target.password.value,
    });

    console.log(body);

    UserService.Login(body)
      .then((response) => response.json())
      .then((res) => {
        login({
          token: res.token,
        });
      })
      .catch((err) => {
        setSnackBar(true);
      });
  };

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setSnackBar(false);
  };

  return (
    <div>
      <Container component="main" maxWidth="xs">
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "primary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Log In
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              fullWidth
              name="username"
              label="Username"
              type="string"
              id="username"
              placeholder="Dummy"
            />

            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              placeholder="Dummy_user"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Log In
            </Button>
          </Box>
        </Box>
      </Container>
      <Snackbar open={snackbar} autoHideDuration={6000} onClose={handleClose}>
        <Alert onClose={handleClose} severity="error" sx={{ width: "100%" }}>
          Failed to log in please try again
        </Alert>
      </Snackbar>
    </div>
  );
};
