import React, { useEffect, useState } from 'react';
import queryString from 'query-string';

export const Error = (props) => {
    const [slug, setSlug] = useState("")

    useEffect(() => {
        if (props && props.location && props.location.search) {
            const query = queryString.parse(props.location.search)
            setSlug(query.slug.toUpperCase())
        }
    }, [props])

    return (
        <div>
            {slug} NOT FOUND
        </div >
    )

}
