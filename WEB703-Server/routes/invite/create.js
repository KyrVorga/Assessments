//SETUP - Modules
var express = require('express');
var router = express.Router();


//SETUP - Import Models
const Group = require('../../models/group')
const Invitation = require('../../models/invitation')


//SETUP - Import Middlewares
const { handleValidationErrors, invitationSchema, validate } = require('../../middlewares/validation');
const { matchedData, checkSchema } = require('express-validator');
const authorize = require('../../middlewares/auth')


/* -------------------------------------------------------------------------- */
/*                     //SECTION - Create Invitation                          */
/* -------------------------------------------------------------------------- */
router.post(
    '/create',
    authorize(['admin', 'user']),
    validate(checkSchema(invitationSchema)),
    handleValidationErrors,
    async (req, res, next) =>{
        try {    
            // Extract data from the validated data.
            const data = matchedData(req);

            const {
                maxUses,
                expiryDate,
                group,
            } = data;

            // Check if group exists in the database
            const existingGroup = await
                Group.findOne({
                    _id: group,
                });

            // Check for group in the database, if not found return an error code 404.
            if (!existingGroup) {
                return res.status(404).json({
                    error: `Group with the ID ${group} not found.`,
                });
            }

            // Generate a random code for the invitation
            let code = Math.random().toString(36).substring(2, 12);

            // Create the invitation
            const newInvitation = new Invitation({
                code,
                status: 'active',
                maxUses,
                currentUses: 0,
                expiryDate,
                group,
            });

            // Save the invitation and get the id
            const invitation = await newInvitation.save();

            // Add the invitation to the group's invitations
            existingGroup.invitations.push(invitation.id);

            // Save the group
            await existingGroup.save();

            // Return a success response
            return res.status(201).json({
                message: `Invitation created successfully.`,
                invitation,
            });            
        } catch (error){
            // If there's an error, respond with a server error.
            console.log(error);
            return res.status(500).json({
                error: "Something went wrong on our end. Please try again. ",
            });
        }
    }
);

module.exports = router;