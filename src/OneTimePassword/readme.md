# One‑time Password

## Summary

One‑time passwords (OTPs) provide an additional authentication factor by generating a short‑lived code based 
on a shared secret. Time‑based One‑Time Passwords (TOTP) derive codes using the current time and a shared key,
as specified in RFC 6238.

## Challenge

- Implement an **HOTP** generator:

  - Take a shared secret key and counter value
  - Compute an HMAC (e.g., HMAC‑SHA1) and truncate to a 6‑ to 8‑digit code

- Build a **TOTP** generator on top of HOTP:

  - Use the current Unix time divided into fixed intervals (e.g., 30 seconds) as the counter
  - Allow a validation window of ±1 time step to account for clock drift

- Create functions to:

  - **Generate** the one‑time password given a secret
  - **Verify** a provided code against the secret

- Design an interface of your choice:

  - Command‑line tool
  - Web API endpoint
  - Mobile or desktop app

## Bonus

- Add **QR code provisioning** for easy secret sharing with authenticator apps
- Support multiple hash algorithms (SHA1, SHA256, SHA512) and configurable code lengths
- Implement **rate limiting** or **retry lockout** to mitigate brute‑force attempts
- Provide a small UI showing the countdown timer until the next code

## Notes and References

- [One‑time password – Wikipedia](https://en.wikipedia.org/wiki/One-time_password)
- [Time‑based One‑time Password – Wikipedia](https://en.wikipedia.org/wiki/Time-based_one-time_password)
- [RFC 6238: TOTP: Time‑based One‑time Password Algorithm](https://www.rfc-editor.org/rfc/rfc6238)
