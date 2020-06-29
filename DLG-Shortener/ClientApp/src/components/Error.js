import React, { useEffect, useState } from 'react';
import queryString from 'query-string';
import classes from "./styles/error.module.css"

export const Error = (props) => {
    const [slug, setSlug] = useState("")

    useEffect(() => {
        if (props && props.location && props.location.search) {
            const query = queryString.parse(props.location.search)
            setSlug(query.slug.toUpperCase())
        }
    }, [props])

    return (
        <div className={classes.errorDiv}>
            {slug} NOT FOUND
        </div >
    )

}
