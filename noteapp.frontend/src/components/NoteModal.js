import React, { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Form, Modal, Button, InputGroup, FormControl } from "react-bootstrap";
import { NewNote, EditNote } from '../services/notes';

export const NewNoteModal = () => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return <div>
        <Button onClick={handleShow} className='btn btn-success'>New Note</Button>
        <NoteModal note={null} handleFormSubmit={NewNote} show={show} handleClose={handleClose} />
    </div>
}

export const EditNoteModal = ({ note }) => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return <div>
        <Button onClick={handleShow} className='btn btn-warning'>Edit</Button>
        <NoteModal note={note} handleFormSubmit={EditNote} show={show} handleClose={handleClose} />
    </div>
}


const NoteModal = ({ note, handleFormSubmit, show, handleClose }) => {
    const [modalNote, setModalNote] = useState({});
    const dispatch = useDispatch();

    useEffect(() => {
        setModalNote(note);
    }, [note]);

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Your Note</Modal.Title>
            </Modal.Header>
            <Form onSubmit={event => {
                event.preventDefault();
                handleFormSubmit(dispatch, modalNote);
            }}>
                <Modal.Body>
                    <InputGroup className="form-group">
                        <FormControl value={modalNote === null ? '' : modalNote.subject}
                            onChange={event => setModalNote({ ...modalNote, subject: event.target.value })} placeholder="Subject" />
                    </InputGroup>
                    <InputGroup>
                        <FormControl value={modalNote === null ? '' : modalNote.reminder}
                            onChange={event => setModalNote({ ...modalNote, reminder: event.target.value })} placeholder="Note" />
                    </InputGroup>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
            </Button>
                    <Button type='submit' variant="primary" onClick={handleClose}>
                        Save
            </Button>
                </Modal.Footer>
            </Form>
        </Modal>
    );
}