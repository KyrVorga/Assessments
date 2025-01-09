const createError = require('http-errors');
const express = require('express');
require('dotenv').config()

// const path = require('path');
const cookieParser = require('cookie-parser');
// const logger = require('morgan');
const session = require('express-session');
const MongoDBStore = require('connect-mongodb-session')(session);
const cors = require('cors');


const userRouter = require('./routes/user/');
const groupRouter = require('./routes/group/');
const inviteRouter = require('./routes/invite/');

const mongoUri = process.env.MONGODB_URI;

const app = express();

const store = new MongoDBStore({
    uri: mongoUri,
    collection: 'sessions',
    expires: 1000 * 60 * 60 * 72, // Session data will be stored for 3 days
});


const corsOptions = {
    origin: 'http://localhost:5173', // specify your client domain
    methods: ['GET', 'POST', 'PUT', 'DELETE'],
    allowedHeaders: ['Content-Type', 'Authorization'],
};

app.use(cors(corsOptions));
app.use(cors({ origin: true, credentials: true }));
store.on('error', (err) => {
    console.error('MongoDB Session Store Error:', err);
});

app.use(
    session({
        secret: process.env.SESSION_SECRET,
        resave: false,
        saveUninitialized: false,
        store: store,
        cookie: {
            maxAge: 1000 * 60 * 60 * 72, // Session cookie will expire in 3 days
        },
    })
);

// // make session user available to ejs
// app.use(function(req, res, next) {
//     res.locals.user = req.session.user;
//     next();
// });


app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());

app.use('/api/user', userRouter);
app.use('/api/group', groupRouter);
app.use('/api/invite', inviteRouter);

// Used by client to check if the user is authenticated
app.get('/api/auth/check', (req, res) => {
    if (req.session.user) {
        res.json({ authenticated: true, user: req.session.user });
    } else {
        res.json({ authenticated: false });
    }
});

// catch 404 and forward to error handler
app.use(function(req, res, next) {
    next(createError(404));
});


// error handler
app.use(function(err, req, res, next) {
    // set locals, only providing error in development
    res.locals.message = err.message;
    res.locals.error = req.app.get('env') === 'development' ? err : {};

    // render the error page
    res.status(err.status || 500);
});

module.exports = app;