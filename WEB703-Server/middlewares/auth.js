function authorize(roles) {
    return (req, res, next) => {
        try {            
            // Check if the origin is trusted.
            // const originIsTrusted = process.env.TRUSTED_ORIGINS.includes(req.hostname) || process.env.TRUSTED_ORIGINS.includes(req.ip);
            // console.log('Origin is trusted:', originIsTrusted);

            // Check if the request is not from Postman
            // if (!req.headers['user-agent'].startsWith('Postman')) {
            //     // If the origin is trusted, skip authentication and authorization.
            //     if (originIsTrusted) {
            //         console.log('Skipping authentication and authorization for trusted origin');
            //         return next();
            //     }
            // }

            const user = req.session.user;
            const id = req.params.id;

            // Check the request is authenticated.
            if (!user) {
                console.log('User not authenticated');
                return res.status(401).send({
                    message: 'You are currently not authenticated.',
                });
            }

            // Check the request is authorized.
            if (!roles.includes(user.role)) {
                console.log('User not authorized');
                return res.status(403).send({
                    message: 'You are not authorized to perform this action.',
                });
            }

            // Check if the request URL is api/user and the ID matches the user ID
            if (req.baseUrl.includes('user') && id !== user._id.toString()) {
                if (!req.url.includes('logout')) {
                    if (user.role !== 'admin') {
                        console.log('User not authorized for this user action');
                        return res.status(403).send({
                            message: 'You are not authorized to perform this action.',
                        });
                    }
                }
            }

            // If the request is PUT or DELETE, make sure the user only modifies itself.
            if (req.method === 'PUT' || req.method === 'DELETE') {
                // Check if the user is an admin or the user whose data is being modified
                if (user.role !== 'admin' && id !== user._id.toString()) {
                    console.log('User not authorized to modify this resource');
                    return res.status(403).send({
                        message: 'You are not authorized to perform this action.',
                    });
                }
            }

            return next();
        } catch (error) {
            console.log('Error during authorization:', error);
            res.status(500).send({'error': 'Something went wrong on our end. Please try again.'});
        }
    };
}

module.exports = authorize;